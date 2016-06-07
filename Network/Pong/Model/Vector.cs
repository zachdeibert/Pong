using System;

namespace Network {
	public class Vector {
		public decimal X {
			get;
			set;
		}

		public decimal Y {
			get;
			set;
		}

		public Vector() {
		}

		public Vector(decimal x, decimal y) {
			X = x;
			Y = y;
		}
	}
}

