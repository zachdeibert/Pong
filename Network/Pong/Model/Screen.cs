﻿using System;

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

		public Screen(ClientModel client) {
			Client = client;
		}
	}
}

