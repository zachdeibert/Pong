using System;

namespace Network {
	internal class ClientCode {
		private readonly GameModel Game;

		public void OnPacketReceived(IPacket raw) {
			if (raw is ConnectPacket) {
				ConnectPacket pkt = (ConnectPacket) raw;
				Game.Clients.Add(pkt.Client);
			} else if (raw is UpdatePacket) {
				UpdatePacket pkt = (UpdatePacket) raw;
				Game.Balls = pkt.Balls;
				Game.LeftPaddle = pkt.LeftPaddle;
				Game.RightPaddle = pkt.RightPaddle;
			}
		}

		public ClientCode(GameModel game) {
			Game = game;
		}
	}
}

