﻿using System.IO;

namespace oledid.SyntaxImprovement.Reflection
{
	public static class EmbeddedResourceReader
	{
		public static string ReadAllText(System.Reflection.Assembly assembly, string resourceName)
		{
			using (var stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (stream == null)
					return null;

				using (var streamReader = new StreamReader(stream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}
	}
}