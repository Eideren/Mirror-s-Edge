namespace MEdge.Core
{
    using System;



    public readonly struct name : IEquatable<name>
    {
        public readonly String Value;
        public name(String v) => Value = string.Equals(v, "none", StringComparison.InvariantCultureIgnoreCase) || string.Equals(v, "", StringComparison.InvariantCultureIgnoreCase) ? "" : v;
        public static implicit operator String(name v) => v.Value;
        public static implicit operator string(name v) => v.Value.ToString();
        public static implicit operator name(String v) => new name(v);
        public static implicit operator name(string v) => new name(v);

        public bool Equals( name other ) => other == this;
        public override bool Equals( object? obj ) => Value.Equals( obj );
        public override int GetHashCode() => Value.GetHashCode();



        public static bool operator ==( name a, name b )
        {
            return string.Equals(a.Value, b.Value, StringComparison.InvariantCultureIgnoreCase);
        }



        public static bool operator !=(name a, name b) => (a == b) == false;
        public override string ToString() => Value.ToString();



        public static bool LooksLikeANone( ReadOnlySpan<char> cs )
        {
            return cs.Length == 0 || cs.Equals( "none", StringComparison.InvariantCultureIgnoreCase );
        }
    }
}