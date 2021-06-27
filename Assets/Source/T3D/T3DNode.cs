namespace MEdge.T3D
{
	using System.Collections.Generic;
	using System.IO;



	public class T3DNode
	{
		public string Definition = "";
		public List<string> Properties = new List<string>();
		public List<T3DNode> Children = new List<T3DNode>();
		public string End = "";



		public T3DNode()
		{
		}



		public T3DNode( TextReader sIn, string def = null )
		{
			if( def != null )
				Definition = def;
			string line;
			while( ( line = sIn.ReadLine() ) != null )
			{
				line = line.TrimStart();
				if( line.StartsWith( "End " ) )
				{
					End = line;
					return;
				}

				if( line.StartsWith( "Begin " ) )
				{
					if( string.IsNullOrWhiteSpace( Definition ) )
						Definition = line;
					else
						Children.Add( new T3DNode( sIn, line ) );
					continue;
				}

				if( line != "" )
					Properties.Add( line );
			}
		}



		public override string ToString()
		{
			using( var sw = new StringWriter() )
			{
				ToString( sw );
				return sw.ToString();
			}
		}



		public void ToString( TextWriter sOut, int depth = 0 )
		{
			for( int i = 0; i < depth; i++ )
				sOut.Write( ' ' );
			sOut.Write( Definition );
			sOut.Write( '\n' );

			var nextDepth = depth + 3;
			foreach( var node in Children )
				node.ToString( sOut, nextDepth );

			foreach( var prop in Properties )
			{
				for( int i = 0; i < nextDepth; i++ )
					sOut.Write( ' ' );
				sOut.Write( prop );
				sOut.Write( '\n' );
			}

			for( int i = 0; i < depth; i++ )
				sOut.Write( ' ' );
			sOut.Write( End );
			sOut.Write( '\n' );
		}
	}
}