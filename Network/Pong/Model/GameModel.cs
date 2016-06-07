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

		public GameModel() {
		}
	}
}

