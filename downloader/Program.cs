using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace downloader
{
	internal class Program
	{
		[STAThread] static void Main(string[] args)
		{
			try
			{
				if (args.Length != 0)
				{
					for (int i = 0; i < args.Length; i++)
					{
						Console.WriteLine("downloading " + args[i] + ". . . ");
						Downloader(args[i], Path.GetFileName(args[i])).Dispose();
						Console.WriteLine("downloaded.");
					}
				}
				else
				{
					Console.WriteLine("usage: downloader.exe [-p/--path PATH] URI...\n");
					Console.WriteLine("downloading file (or files) from URIs to desktop. if \"-p\" or \"--path\" and path is written, then file will be installed, into PATH folder.");
				}
			}
			catch (Exception ex) { Console.WriteLine("eRrOr!!\n" + ex.Message); }
		}
		public static WebClient Downloader(string uri, string filename) => Downloader(uri, filename, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
		public static WebClient Downloader(string uri, string filename, string path)
		{
			try
			{
				WebClient x = new WebClient();
				Uri uried = new Uri(uri);
				//uried.
				x.DownloadFileAsync(uried, path + "\\" + filename);
				return x;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			return null;
		}
		public static void DownloadInfo(object sender, DownloadProgressChangedEventArgs e)
		{
			Console.WriteLine("downloaded: " + e.ProgressPercentage + "%");
			for (int j = 0; j < 10; j++) Console.Write(j <= e.ProgressPercentage / 10 ? "#" : "_");
			Console.SetCursorPosition(0, Console.CursorTop - 1);
		}
	}
}