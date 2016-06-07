using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Network {
	public class NetworkClient : IDisposable {
		public event Action<IPacket> PacketReceived;
		public event Action<IOException> Errored;
		private readonly TcpClient Client;
		private readonly Stream Network;
		private readonly Thread Thread;
		private readonly BinaryFormatter fmt;
		private bool Disposed;

		public void Dispose() {
			if (!Disposed) {
				Thread.Interrupt();
				Thread.Join();
				Network.Close();
				Client.Close();
				Network.Dispose();
			}
		}

		public void SendPacket(IPacket pkt) {
			if (Disposed) {
				throw new ObjectDisposedException("NetworkClient");
			}
			try {
				fmt.Serialize(Network, pkt);
			} catch (IOException ex) {
				if (Errored == null) {
					Console.Error.WriteLine(ex);
				} else {
					Errored(ex);
				}
			}
		}

		private void ReadingThread() {
			if (Disposed) {
				throw new ObjectDisposedException("NetworkClient");
			}
			try {
				while (true) {
					IPacket pkt = (IPacket) fmt.Deserialize(Network);
					if (PacketReceived != null) {
						PacketReceived(pkt);
					}
				}
			} catch (IOException ex) {
				if (Errored == null) {
					Console.Error.WriteLine(ex);
				} else {
					Errored(ex);
				}
			}
		}

		public NetworkClient(IPAddress addr) {
			Client = new TcpClient(addr);
			Network = Client.GetStream();
			fmt = new BinaryFormatter();
			Thread = new Thread(ReadingThread);
			Thread.Start();
		}

		~NetworkClient() {
			Dispose();
		}
	}
}

