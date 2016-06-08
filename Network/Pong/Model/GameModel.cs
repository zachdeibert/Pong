using System;
using System.Collections.Generic;

namespace Network {
	[Serializable]
	public class GameModel {
		public List<ClientModel> Clients;

		public Paddle LeftPaddle;

		public Paddle RightPaddle;

		public List<Ball> Balls;

		public Player LeftPlayer;

		public Player RightPlayer;

		public void CreateBallAndPaddles() {
			LeftPaddle = new Paddle(Clients[0]);
			RightPaddle = new Paddle(Clients[Clients.Count - 1]);
			Balls.Add(new Ball(this));
		}

		public GameModel() {
			Clients = new List<ClientModel>();
			Balls = new List<Ball>();
		}
	}
}

