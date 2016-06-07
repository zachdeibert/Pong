using System;
using System.Net;

namespace Network {
	public static class NetworkFactory {
		public static NetworkClient CreateClient(IPEndPoint addr) {
			NetworkClient client = new NetworkClient(addr);
			return client;
		}

		public static NetworkServer CreateServer(int port) {
			NetworkServer server = new NetworkServer(port);
			return server;
		}
	}
}

