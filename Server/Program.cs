using System;
using System.Net;
using Network;

namespace Server {
	public static class MainClass {
		private const int DefaultPort = 35071;

		public static void Main(string[] args) {
			int port = DefaultPort;
			if (args.Length == 1) {
				if (!int.TryParse(args[0], out port)) {
					Console.Error.WriteLine("Unable to parse port number {0}", args[0]);
					Console.Error.WriteLine("Using port {0} instead", port);
				}
			}
			NetworkFactory.CreateServer(port, new GameModel());
			Console.WriteLine("Server started on {0}:{1}", IPAddress.Any, port);
			Console.WriteLine("Press any key to stop the server...");
			Console.ReadKey(true);
			Environment.Exit(0);
		}
	}
}
