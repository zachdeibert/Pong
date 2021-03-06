﻿using System;

namespace Network {
	[Serializable]
	public class Ball {
		private const decimal VelocityScale = 0.5m;
		private const decimal AccelerationScale = 0.01m;
		private const decimal OverAcceleration = 1;
		private static readonly Random RNG = new Random();
		private readonly GameModel Game;
		private decimal _Size;

		public Screen Screen;

		public Vector Location;

		public Vector Velocity;

		public decimal AngularAcceleration;

		public decimal Size;

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
			if (Location.Y < Size / 2) {
				Velocity.Y *= -1;
				Location.Y = Size / 2;
			} else if (Location.Y > 1 - Size / 2) {
				Velocity.Y *= -1;
				Location.Y = 1 - Size / 2;
			}
			if (Location.X < Size / 2) {
				if (Screen.HasMoreLeft) {
					Screen = new Screen(Game.Clients[Screen.X - 1]);
					Location.X += 1;
				} else if (Game.LeftPaddle.Y + Game.LeftPaddle.Height / 2 >= Location.Y && Game.LeftPaddle.Y - Game.LeftPaddle.Height / 2 <= Location.Y) {
					Velocity.X *= -1;
					Location.X = Size / 2;
				} else {
					++Game.RightPlayer.Score;
					Reset();
				}
			} else if (Location.X > 1 - Size / 2) {
				if (Screen.HasMoreRight) {
					Screen = new Screen(Game.Clients[Screen.X + 1]);
					Location.X -= 1;
				} else if (Game.RightPaddle.Y + Game.RightPaddle.Height / 2 >= Location.Y && Game.RightPaddle.Y - Game.RightPaddle.Height / 2 <= Location.Y) {
					Velocity.X *= -1;
					Location.X = 1 - Size / 2;
				} else {
					++Game.LeftPlayer.Score;
					Reset();
				}
			}
		}

		public void Reset() {
			Screen = new Screen(Game.Clients[Game.Clients.Count / 2]);
			Location = new Vector(0.5m, 0.5m);
			Velocity = new Vector((((decimal) RNG.NextDouble()) * 2m - 1m) * VelocityScale, (((decimal) RNG.NextDouble()) * 2m - 1m) * VelocityScale);
			AngularAcceleration = ((decimal) RNG.NextDouble()) * AccelerationScale;
			Size = 0.1m;
		}

		public Ball(GameModel model) {
			Game = model;
			Reset();
		}
	}
}

