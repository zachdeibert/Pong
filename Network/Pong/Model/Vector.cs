using System;

namespace Network {
	[Serializable]
	public class Vector {
		public decimal X {
			get;
			set;
		}

		public decimal Y {
			get;
			set;
		}

		public static Vector operator +(Vector a, Vector b) {
			return new Vector(a.X + b.X, a.Y + b.Y);
		}

		public static Vector operator *(Vector a, decimal b) {
			return new Vector(a.X * b, a.Y * b);
		}

		public static Vector operator *(decimal b, Vector a) {
			return a * b;
		}

		public Vector() {
		}

		public Vector(decimal x, decimal y) {
			X = x;
			Y = y;
		}
	}
}

