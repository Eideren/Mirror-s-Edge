namespace MEdge.Core
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;



	public static class NativeMarkers
	{
		public readonly struct MarkerData : IEquatable<MarkerData>
		{
			public readonly int Line;
			public readonly string Member;
			public readonly string FilePath;



			public MarkerData( int pLine, string pMember, string pFilePath )
			{
				Line = pLine;
				Member = pMember;
				FilePath = pFilePath;
			}



			public override bool Equals( object obj )
			{
				return obj is MarkerData other && Equals( other );
			}



			public override int GetHashCode()
			{
				return HashCode.Combine( Line, Member, FilePath );
			}



			public bool Equals( MarkerData other )
			{
				return Line == other.Line && Member == other.Member && FilePath == other.FilePath;
			}
		}



		public static HashSet<MarkerData> Marked = new HashSet<MarkerData>();
		public static void MarkUnimplemented([ CallerLineNumber ] int line = 0, [ CallerMemberName ] string member = "member", [ CallerFilePath ] string filePath = "filePath" )
		{
			Marked.Add( new MarkerData( line, member, filePath ) );
		}
	}
}