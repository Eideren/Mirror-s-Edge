namespace MEdge.Core
{
    using System;



    public readonly struct name : IEquatable<name>
    {
        public readonly String Value;
        static readonly String NoneValue = "";



        public name( String v )
        {
            Value = LooksLikeANone( v.ToString() ) ? NoneValue : v;
        }
        public static implicit operator String(name v) => v.Value;
        public static implicit operator string(name v) => v.Value.ToString();
        public static implicit operator name(String v) => new name(v);
        public static implicit operator name(string v) => new name(v);

        public bool Equals( name other ) => other == this;
        public override bool Equals( object? obj ) => Value.Equals( obj );
        public override int GetHashCode() => Value.GetHashCode();



        public static bool operator ==( name a, name b )
        {
            var sA = a.ToString();
            var sB = b.ToString();
            return sA.Length == sB.Length && (ReferenceEquals(sA, sB) || string.Equals(sA, sB, StringComparison.InvariantCultureIgnoreCase));
        }



        public static bool operator !=(name a, name b) => (a == b) == false;
        public override string ToString() => Value.ToString();



        public static bool LooksLikeANone( ReadOnlySpan<char> cs )
        {
            return cs.Length == 0 || cs.Equals( "none", StringComparison.InvariantCultureIgnoreCase );
        }
    }
}