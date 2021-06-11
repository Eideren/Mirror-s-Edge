namespace MEdge.AnimNodeEditor
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Engine;
	using NodeEditor;
	using T3D;
	using Reflection;
	using UnityEditor;
	using static UnityEngine.Debug;



	public class AnimNodeEditorWindow : NodeEditorWindow
	{
		public T3DFile File;
		List<AnimNodeDrawer> nodes;



		[ MenuItem( "Window/Anim Node Editor" ) ]
		static void Init()
		{
			var window = GetWindow<AnimNodeEditorWindow>();
			window.Show();
		}



		public AnimNodeEditorWindow()
		{
		}



		public AnimNodeEditorWindow( T3DFile f )
		{
			File = f;
			Show();
		}



		IEnumerable<T3DNode> EnumerateNodes( T3DNode e )
		{
			yield return e;
			foreach( var child in e.Children )
			{
				foreach( var c in EnumerateNodes( child ) )
				{
					yield return c;
				}
			}
		}



		public override IEnumerable<INode> Nodes()
		{
			if( nodes == null )
			{
				nodes = new List<AnimNodeDrawer>();

				Dictionary<T3DNode, object> Nodes = new Dictionary<T3DNode, object>();

				var types = typeof(MEdge.Core.Object).Assembly.GetTypes();
				foreach( var node in EnumerateNodes( File.Root ) )
				{
					var Class = node.TryExtract( "Class" );
					var Name = node.TryExtract( "Name" );
					var ObjName = node.TryExtract( "ObjName" );
					var ArcheType = node.TryExtract( "Archetype" );

					var t = types.FirstOrDefault( x => x.Name == Class );
					if( t != null && Activator.CreateInstance( t ) is object newObject )
					{
						ReflectionData.ForeachField( ref newObject, delegate( IField field, CachedContainer cache )
						{
							var prop = node.Properties.FirstOrDefault( x => x.StartsWith( field.Info.Name + "=" ) );
							if( prop == null )
								return;

							var value = prop.Substring( prop.IndexOf( '=' ) + 1 );
							try
							{
								switch( field )
								{
									case IField<Boolean> fBoolean: fBoolean.Ref( cache ) = System.Boolean.Parse( value ); break;
									case IField<Byte> fByte: fByte.Ref( cache ) = System.Byte.Parse( value ); break;
									case IField<Char> fChar: fChar.Ref( cache ) = System.Char.Parse( value ); break;
									case IField<DateTime> fDateTime: fDateTime.Ref( cache ) = System.DateTime.Parse( value ); break;
									case IField<Decimal> fDecimal: fDecimal.Ref( cache ) = System.Decimal.Parse( value ); break;
									case IField<Double> fDouble: fDouble.Ref( cache ) = System.Double.Parse( value ); break;
									case IField<Int16> fInt16: fInt16.Ref( cache ) = System.Int16.Parse( value ); break;
									case IField<Int32> fInt32: fInt32.Ref( cache ) = System.Int32.Parse( value ); break;
									case IField<Int64> fInt64: fInt64.Ref( cache ) = System.Int64.Parse( value ); break;
									case IField<SByte> fSByte: fSByte.Ref( cache ) = System.SByte.Parse( value ); break;
									case IField<Single> fSingle: fSingle.Ref( cache ) = System.Single.Parse( value ); break;
									case IField<UInt16> fUInt16: fUInt16.Ref( cache ) = System.UInt16.Parse( value ); break;
									case IField<UInt32> fUInt32: fUInt32.Ref( cache ) = System.UInt32.Parse( value ); break;
									case IField<UInt64> fUInt64: fUInt64.Ref( cache ) = System.UInt64.Parse( value ); break;
									case IField<MEdge.Core.name> fName: fName.Ref( cache ) = value; break;
									case IField<MEdge.Core.String> fString: fString.Ref( cache ) = value; break;
									case IField<string> fString: fString.Ref( cache ) = value; break;
									default:
									{
										LogWarning( $"Parsing for {field.Info.FieldType} not implemented ({prop})" );
										break;
									}
								}
							}
							catch( Exception e )
							{
								LogWarning( $"Could not parse {value} into '{field.Info.FieldType}': {e}" );
							}
						} );

						if( newObject is AnimNode a )
							nodes.Add( new AnimNodeDrawer( a ) );
						Nodes.Add( node, newObject );
					}
					else
						LogWarning( $"Could not create instance of {Class} - {t}" );
				}
			}


			return nodes;
		}
	}
}