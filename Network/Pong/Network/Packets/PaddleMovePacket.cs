using System;

namespace Network {
	[Serializable]
	public class PaddleMovePacket : IPacket {
		public Paddle Paddle {
			get;
			set;
		}

		public PaddleMovePacket(Paddle paddle) {
			Paddle = paddle;
		}
	}
}

