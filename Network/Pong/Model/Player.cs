using System;

namespace Network {
	[Serializable]
	public class Player {
		public string Name {
			get;
			set;
		}

		public int Score {
			get;
			set;
		}

		public Player() {
		}
	}
}

