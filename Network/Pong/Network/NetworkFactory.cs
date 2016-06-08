using System;
using System.Net;

namespace Network {
	public static class NetworkFactory {
		public static NetworkClient CreateClient(IPEndPoint addr, GameModel game) {
			NetworkClient client = new NetworkClient(addr);
			client.PacketReceived += new ClientCode(game).OnPacketReceived;
			return client;
		}

		public static void ConnectClient(NetworkClient client, int location, string name = null) {
			ClientModel c = new ClientModel();
			c.Location = location;
			client.SendPacket(new ConnectPacket(c));
			if (name != null) {
				client.SendPacket(new NamePacket(name, c.Mode));
			}
		}

		public static NetworkServer CreateServer(int port, GameModel game) {
			NetworkServer server = new NetworkServer(port);
			server.PacketReceived += new ServerCode(game).OnPacketReceived;
			return server;
		}
	}
}

