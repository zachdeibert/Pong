using System;

namespace Network {
	public class Ball {
		public Screen Screen {
			get;
			set;
		}

		public Vector Location {
			get;
			set;
		}

		public Vector Velocity {
			get;
			set;
		}

		public Vector Acceleration {
			get;
			set;
		}

		public Ball(GameModel model) {
		}
	}
}

