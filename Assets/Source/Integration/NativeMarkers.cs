namespace MEdge.Core
{
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;



	public static class NativeMarkers
	{
		public readonly struct MarkerData
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
				return obj is MarkerData m && m.Line == Line && m.Member == Member && m.FilePath == FilePath;
			}



			public override int GetHashCode()
			{
				var previousHash = unchecked( ( 1009 * 9176 ) + Line.GetHashCode() );
				previousHash = unchecked( ( previousHash * 9176 ) + Member.GetHashCode() );
				return unchecked( ( previousHash * 9176 ) + FilePath.GetHashCode() );
			}
		}



		public static HashSet<MarkerData> Marked = new HashSet<MarkerData>();
		public static void MarkUnimplemented([ CallerLineNumber ] int line = 0, [ CallerMemberName ] string member = "member", [ CallerFilePath ] string filePath = "filePath" )
		{
			Marked.Add( new MarkerData( line, member, filePath ) );
		}
	}
}