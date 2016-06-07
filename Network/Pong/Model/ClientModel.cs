using System;
using System.Net;

namespace Network {
	[Serializable]
	public class ClientModel {
		public IPAddress IP {
			get;
			set;
		}

		public ClientMode Mode {
			get {
				if (Location == 0) {
					return ClientMode.LeftEnd;
				} else if (Location == Game.Clients.Count) {
					return ClientMode.MiddleNode;
				} else {
					return ClientMode.RightEnd;
				}
			}
		}

		public int Location {
			get;
			set;
		}

		public GameModel Game {
			get;
			set;
		}

		public ClientModel() {
		}
	}
}

