using System;

namespace Network {
	[Serializable]
	public class PaddleMovePacket : IPacket {
		public Paddle Paddle;

		public PaddleMovePacket(Paddle paddle) {
			Paddle = paddle;
		}
	}
}

