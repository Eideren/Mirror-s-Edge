namespace MEdge
{
	using System;
	using JetBrains.Annotations;



	public static class StringExtension
	{
		[ CanBeNull ]
		public static string Between( this string input, string indexA, string indexB, bool useRestIfBFails = false )
		{
			var i = input.IndexOf( indexA, StringComparison.Ordinal );
			if( i < 0 )
				return null;
			i += indexA.Length;
			var i2 = input.IndexOf( indexB, i );
			if( i2 < 0 && useRestIfBFails )
				i2 = input.Length;
			if( i2 < 0 )
				return null;
			return input.Substring( i, i2 - i );
		}
	}
}