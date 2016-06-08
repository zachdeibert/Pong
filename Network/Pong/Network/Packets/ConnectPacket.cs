using System;

namespace Network {
	[Serializable]
	public class ConnectPacket : IPacket {
		public ClientModel Client;

		public ConnectPacket(ClientModel client) {
			Client = client;
		}
	}
}

