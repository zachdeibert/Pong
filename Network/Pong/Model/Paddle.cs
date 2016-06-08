using System;

namespace Network {
	[Serializable]
	public class Paddle {
		private ClientMode _Mode;
		private ClientModel _Model;
		private decimal _Y;
		private decimal _Height;

		public ClientMode Mode {
			get {
				return _Mode;
			}
			set {
				if (_Mode == ClientMode.MiddleNode) {
					throw new ArgumentException("Paddles do not go in the middle");
				}
				_Mode = value;
			}
		}

		public ClientModel Model {
			get {
				return _Model;
			}
			set {
				if (_Mode != value.Mode) {
					throw new ArgumentException("Invalid client for this type of paddle");
				}
				_Model = value;
			}
		}

		public decimal Y {
			get {
				return _Y;
			}
			set {
				if (value < 0) {
					value = 0;
				} else if (value > 1) {
					value = 1;
				}
				_Y = value;
			}
		}

		public decimal Height {
			get {
				return _Height;
			}
			set {
				_Height = value;
			}
		}

		public Paddle(ClientModel client) {
			Mode = client.Mode;
			Model = client;
			Y = 0.5m;
			Height = 0.15m;
		}
	}
}

