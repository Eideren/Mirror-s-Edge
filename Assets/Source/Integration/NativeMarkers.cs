namespace MEdge.Core
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;



	public static class NativeMarkers
	{
		public readonly struct MarkerData : IEquatable<MarkerData>
		{
			public readonly string Description;
			public readonly int Line;
			public readonly string Member;
			public readonly string FilePath;



			public MarkerData( string description, int pLine, string pMember, string pFilePath )
			{
				Description = description;
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
				return HashCode.Combine( Description, Line, Member, FilePath );
			}



			public bool Equals( MarkerData other )
			{
				return Description == other.Description && Line == other.Line && Member == other.Member && FilePath == other.FilePath;
			}
		}



		public static HashSet<MarkerData> Marked = new HashSet<MarkerData>();
		public static void MarkUnimplemented(string description = null, [ CallerLineNumber ] int line = 0, [ CallerMemberName ] string member = "member", [ CallerFilePath ] string filePath = "filePath" )
		{
			if(Marked.Count == 0)
				UnityEngine.Debug.LogWarning("New unimplemented marker logged, exit play mode to dump them to the console");
			Marked.Add( new MarkerData( description, line, member, filePath ) );
		}
	}
}