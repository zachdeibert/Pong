using System;

namespace Network {
	[Serializable]
	public class Screen {
		public ClientModel Client;

		public int X {
			get {
				return Client.Location;
			}
		}

		public bool HasMoreLeft {
			get {
				return Client.Mode == ClientMode.LeftEnd;
			}
		}

		public bool HasMoreRight {
			get {
				return Client.Mode == ClientMode.RightEnd;
			}
		}

		public override bool Equals(object obj) {
			if (obj is Screen) {
				Screen s = (Screen) obj;
				return X == s.X;
			}
			return false;
		}

		public Screen(ClientModel client) {
			Client = client;
		}
	}
}

