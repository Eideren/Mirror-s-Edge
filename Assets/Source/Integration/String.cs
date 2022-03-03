namespace MEdge.Core
{
	public readonly struct String
	{
		/// <summary>
		/// Have to always test this value otherwise 'default' wouldn't work
		/// </summary>
		string ValidVal => _invalidVal ?? "";
		readonly string _invalidVal;
		
		String( string s ) => _invalidVal = s ?? "";
		public static implicit operator String(string v) => new String(v);
		public static implicit operator string(String v) => v.ValidVal;
		



		public override bool Equals( object? obj )
		{
			if( obj is name n )
				return ToString() == n.ToString();
			if( obj is String Str )
				return ToString() == Str.ToString();
			if( obj is string sstr )
				return ToString() == sstr;
			return false;
		}



		public override int GetHashCode() => ValidVal.GetHashCode();
		public static bool operator ==(String a, String b) => a.ToString() == b.ToString();
		public static bool operator !=(String a, String b) => (a == b) == false;
		public override string ToString() => ValidVal;
	}
}