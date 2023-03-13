using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace downloader
{
	internal class Program
	{
		static void Main(string[] args)
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
					Console.Write("choose what i should download: ");
					string uri = Console.ReadLine();
					Downloader(uri, Path.GetFileName(uri)).Dispose();
					Console.WriteLine("Downloaded.");
				}
			}
			catch (Exception ex) { Console.WriteLine("eRrOr!!\n" + ex.Message); }
			Process.Start(".");
		}
		public static WebClient Downloader(string uri, string filename)
		{
			try
			{
				WebClient x = new WebClient();
				x.DownloadFile(uri, filename);
				return x;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			return null;
		}
	}
}