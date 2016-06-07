using System;
using System.Threading;

namespace Network {
	public class Simulator {
		private const decimal InverseSpeed = 1000;
		private readonly GameModel Game;
		private readonly Thread Thread;

		private void Run() {
			Game.CreateBallAndPaddles();
			DateTime lastFrame = DateTime.Now;
			while (true) {
				DateTime frame = DateTime.Now;
				TimeSpan diff = frame - lastFrame;
				lastFrame = frame;
				long ticks = diff.Ticks;
				Game.Balls.ForEach(b => b.Tick(((decimal) ticks) / InverseSpeed));
			}
		}

		public void Stop() {
			Thread.Interrupt();
		}

		public Simulator(GameModel game) {
			Game = game;
			Thread = new Thread(Run);
			Thread.Start();
		}
	}
}

