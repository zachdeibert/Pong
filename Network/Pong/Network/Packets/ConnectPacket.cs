using System;

namespace Network {
	[Serializable]
	public class ConnectPacket : IPacket {
		public ClientModel Client {
			get;
			set;
		}

		public ConnectPacket(ClientModel client) {
			Client = client;
		}
	}
}

