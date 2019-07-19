using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GitMap
{
	class Git
	{
		public Git(String path)
		{
			Path = path;

			var configPath = System.IO.Path.Combine(path, ".git", "config");
			var config = File.ReadAllText(configPath);

			var regex = new Regex(@"git@github\.com:.+\/.+\.git");
			Url = regex.Match(config).Groups[0].Value;
		}

		public String Path { get; }
		public String Url { get; }

		public override string ToString()
		{
			return $"mkdir {Path}\n" +
				$"cd {Path}\n" +
				$"git clone {Url} .\n";
		}
	}
}
