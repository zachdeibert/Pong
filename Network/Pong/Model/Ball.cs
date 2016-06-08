using System;

namespace Network {
	[Serializable]
	public class Ball {
		private const decimal VelocityScale = 0.5m;
		private const decimal AccelerationScale = 0.01m;
		private const decimal OverAcceleration = 1;
		private static readonly Random RNG = new Random();
		private readonly GameModel Game;

		public Screen Screen;

		public Vector Location;

		public Vector Velocity;

		public decimal AngularAcceleration;

		private bool HasOverAcceleration {
			get {
				return AngularAcceleration >= OverAcceleration;
			}
		}

		public void Tick(decimal dt) {
			bool before = HasOverAcceleration;
			Velocity *= (decimal) Math.Pow((double) (1m + AngularAcceleration), (double) dt);
			if (!before && HasOverAcceleration) {
				Game.Balls.Add(new Ball(Game));
			}
			Location += Velocity * dt;
			if (Location.Y < 0) {
				Velocity.Y *= -1;
				Location.Y = 0;
			} else if (Location.Y > 1) {
				Velocity.Y *= -1;
				Location.Y = 1;
			}
			if (Location.X < 0) {
				if (Screen.HasMoreLeft) {
					Screen = new Screen(Game.Clients[Screen.X - 1]);
					Location.X += 1;
				} else {
					Velocity.X *= -1;
					Location.X = 0;
				}
			} else if (Location.X > 1) {
				if (Screen.HasMoreRight) {
					Screen = new Screen(Game.Clients[Screen.X + 1]);
					Location.X -= 1;
				} else {
					Velocity.X *= -1;
					Location.X = 1;
				}
			}
		}

		public Ball(GameModel model) {
			Game = model;
			Screen = new Screen(model.Clients[model.Clients.Count / 2]);
			Location = new Vector(0.5m, 0.5m);
			Velocity = new Vector((((decimal) RNG.NextDouble()) * 2m - 1m) * VelocityScale, (((decimal) RNG.NextDouble()) * 2m - 1m) * VelocityScale);
			AngularAcceleration = ((decimal) RNG.NextDouble()) * AccelerationScale;
		}
	}
}

