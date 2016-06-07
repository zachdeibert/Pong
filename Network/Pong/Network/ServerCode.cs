using System;

namespace Network {
	internal class ServerCode {
		private readonly GameModel Game;

		public void OnPacketReceived(IPacket raw) {
			if (raw is ConnectPacket) {
				ConnectPacket pkt = (ConnectPacket) raw;
				Game.Clients.Add(pkt.Client);
			} else if (raw is PaddleMovePacket) {
				PaddleMovePacket pkt = (PaddleMovePacket) raw;
				if (pkt.Paddle.Mode == ClientMode.LeftEnd) {
					Game.LeftPaddle = pkt.Paddle;
				} else {
					Game.RightPaddle = pkt.Paddle;
				}
			}
		}

		public ServerCode(GameModel game) {
			Game = game;
		}
	}
}

