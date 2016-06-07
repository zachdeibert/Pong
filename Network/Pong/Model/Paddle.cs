using System;

namespace Network {
	public class Paddle {
		private ClientMode _Mode;
		private ClientModel _Model;

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
			}
		}

		public Paddle() {
		}
	}
}

