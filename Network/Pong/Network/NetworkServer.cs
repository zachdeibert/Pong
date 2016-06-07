using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Network {
	public class NetworkServer {
		public event Action<IPacket> PacketReceived;
		public event Action<IOException> Errored;
		private readonly List<Thread> Threads;
		private readonly List<TcpClient> Clients;
		private readonly List<Stream> Streams;
		private readonly TcpListener Listener;
		private readonly BinaryFormatter fmt;
		private bool Disposed;

		public void Dispose() {
			if (!Disposed) {
				foreach (Thread thread in Threads) {
					thread.Interrupt();
				}
				foreach (Stream stream in Streams) {
					stream.Close();
				}
				foreach (TcpClient client in Clients) {
					client.Close();
				}
				foreach (Stream stream in Streams) {
					stream.Dispose();
				}
				Threads.Clear();
				Clients.Clear();
				Streams.Clear();
			}
		}

		public void SendPacket(IPacket pkt) {
			if (Disposed) {
				throw new ObjectDisposedException("NetworkServer");
			}
			try {
				foreach (Stream stream in Streams) {
					fmt.Serialize(stream, pkt);
				}
			} catch (IOException ex) {
				if (Errored == null) {
					Console.Error.WriteLine(ex);
				} else {
					Errored(ex);
				}
			}
		}

		private void ReadingThread(object obj) {
			if (Disposed) {
				throw new ObjectDisposedException("NetworkServer");
			}
			TcpClient client = (TcpClient) obj;
			Stream stream = client.GetStream();
			Streams.Add(stream);
			try {
				while (true) {
					IPacket pkt = (IPacket) fmt.Deserialize(stream);
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

		private void AcceptingThread() {
			if (Disposed) {
				throw new ObjectDisposedException("NetworkServer");
			}
			try {
				while (true) {
					TcpClient client = Listener.AcceptTcpClient();
					Thread thread = new Thread(ReadingThread);
					thread.Start(client);
					Threads.Add(thread);
					Clients.Add(client);
				}
			} catch (IOException ex) {
				if (Errored == null) {
					Console.Error.WriteLine(ex);
				} else {
					Errored(ex);
				}
			}
		}

		public NetworkServer(int port) {
			Threads = new List<Thread>();
			Clients = new List<TcpClient>();
			Streams = new List<Stream>();
			Listener = new TcpListener(IPAddress.Any, port);
			fmt = new BinaryFormatter();
			Thread thread = new Thread(AcceptingThread);
			thread.Start();
			Threads.Add(thread);
		}

		~NetworkServer() {
			Dispose();
		}
	}
}

