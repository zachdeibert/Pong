using System;
using System.Collections.Generic;

namespace Network {
	public class GameModel {
		public List<ClientModel> Clients {
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

		public List<Ball> Balls {
			get;
			set;
		}

		public void CreateBallAndPaddles() {
			Clients = Clients.AsReadOnly();
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

