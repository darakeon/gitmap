using System;
using System.IO;
using System.Linq;

namespace GitMap
{
	class Program
	{
		public static void Main(String[] args)
		{
			Console.WriteLine("Hey, listen!");

			var gits = getAllGit(args[0]);

			gits.ToList().ForEach(Console.WriteLine);

			Console.ReadLine();
		}

		private static Git[] getAllGit(String path)
		{
			var directories = Directory.GetDirectories(path);

			var gitDir = directories.SingleOrDefault(
				d => d.EndsWith(@"\.git")
			);

			if (gitDir != null)
			{
				return new [] { new Git(path) };
			}

			return directories
				.Select(getAllGit)
				.SelectMany(d => d)
				.ToArray();
		}
	}
}
