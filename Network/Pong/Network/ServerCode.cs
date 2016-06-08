using System;
using System.Linq;

namespace Network {
	internal class ServerCode {
		private readonly GameModel Game;
		private Simulator Simulator;

		public bool IsContinuous {
			get {
				return Game.Clients.Select(c => c.Location).Max() == Game.Clients.Count;
			}
		}

		public void OnPacketReceived(IPacket raw) {
			if (raw is ConnectPacket) {
				ConnectPacket pkt = (ConnectPacket) raw;
				pkt.Client.Game = Game;
				bool before = IsContinuous;
				Game.Clients.Add(pkt.Client);
				if (before) {
					if (!IsContinuous) {
						Simulator.Stop();
					}
				} else if (IsContinuous) {
					Simulator = new Simulator(Game);
				}
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

