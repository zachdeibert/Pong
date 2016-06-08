using System;
using System.Collections.Generic;

namespace Network {
	[Serializable]
	public class UpdatePacket : IPacket {
		public List<Ball> Balls;

		public Paddle LeftPaddle;

		public Paddle RightPaddle;

		public Player LeftPlayer;

		public Player RightPlayer;

		public UpdatePacket(GameModel model) {
			Balls = model.Balls;
			LeftPaddle = model.LeftPaddle;
			RightPaddle = model.RightPaddle;
			LeftPlayer = model.LeftPlayer;
			RightPlayer = model.RightPlayer;
		}
	}
}

