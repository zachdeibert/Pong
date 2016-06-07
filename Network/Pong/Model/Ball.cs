using System;

namespace Network {
	[Serializable]
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

		public void Tick(decimal dt) {
			Velocity += Acceleration * dt;
			Location += Velocity * dt;
		}

		public Ball(GameModel model) {
		}
	}
}

