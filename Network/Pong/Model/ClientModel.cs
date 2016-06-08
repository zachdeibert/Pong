using System;
using System.Net;

namespace Network {
	[Serializable]
	public class ClientModel {
		public IPAddress IP;

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

		public int Location;

		[NonSerialized]
		public GameModel Game;

		public ClientModel() {
		}
	}
}

