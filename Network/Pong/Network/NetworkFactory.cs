using System;
using System.Net;

namespace Network {
	public static class NetworkFactory {
		public static NetworkClient CreateClient(IPEndPoint addr, GameModel game) {
			NetworkClient client = new NetworkClient(addr);
			client.PacketReceived += new ClientCode(game).OnPacketReceived;
			return client;
		}

		public static NetworkServer CreateServer(int port, GameModel game) {
			NetworkServer server = new NetworkServer(port);
			server.PacketReceived += new ServerCode(game).OnPacketReceived;
			return server;
		}
	}
}

