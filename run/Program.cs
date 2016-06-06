using System;
using System.IO;
using System.Diagnostics;

namespace run
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string dir;
			if (DoesSolutionExist (out dir)) {
				Console.WriteLine ("Building " + dir + "...");
				ExecuteShellCommand ("xbuild", dir + ".sln");
				Console.WriteLine ("Running...");
				string arguments = Combine (args);
				ExecuteShellCommand ("mono", dir + "/bin/Debug/" + dir + ".exe " + arguments);
			} else {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("(Error) Solution file does not exist");
			}
		}

		public static string Combine(string[] arr)
		{
			string combine = "";
			foreach (string str in arr)
				combine += str + " ";
			return combine.TrimEnd(' ');
		}

		public static bool DoesSolutionExist (out string file)
		{
			string directory = Directory.GetCurrentDirectory ();
			Console.WriteLine (directory);
			string[] files = Directory.GetFiles (directory);
			foreach (string fl in files) {
				if (Path.GetFileName (fl).EndsWith(".sln")){
					file = Path.GetFileName (fl).Replace(".sln", "");
					return true;
				}
			}
			file = "";
			return false;
		}

		public static void ExecuteShellCommand(string command, string args)
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.FileName = command;
			info.Arguments = args;

			info.UseShellExecute = false;
			info.CreateNoWindow = true;

			info.RedirectStandardOutput = false;
			info.RedirectStandardError = false;

			Process p = Process.Start(info);
			p.WaitForExit();
		}
	}
}
