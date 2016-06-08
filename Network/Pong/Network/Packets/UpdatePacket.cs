using System;
using System.Collections.Generic;

namespace Network {
	[Serializable]
	public class UpdatePacket : IPacket {
		public List<Ball> Balls {
			get;
			set;
		}

		public Paddle LeftPaddle {
			get;
			set;
		}

		public Paddle RightPaddle {
			get;
			set;
		}

		public Player LeftPlayer {
			get;
			set;
		}

		public Player RightPlayer {
			get;
			set;
		}

		public UpdatePacket(GameModel model) {
			Balls = model.Balls;
			LeftPaddle = model.LeftPaddle;
			RightPaddle = model.RightPaddle;
			LeftPlayer = model.LeftPlayer;
			RightPlayer = model.RightPlayer;
		}
	}
}

