using System;

namespace Network {
	public class NamePacket : IPacket {
		private ClientMode _Side;

		public string Name;

		public ClientMode Side {
			get {
				return _Side;
			}
			set {
				if (value == ClientMode.MiddleNode) {
					throw new ArgumentException("The middle nodes cannot be named");
				}
				_Side = value;
			}
		}

		public NamePacket() {
		}

		public NamePacket(string name, ClientMode side) {
			Name = name;
			Side = side;
		}
	}
}

