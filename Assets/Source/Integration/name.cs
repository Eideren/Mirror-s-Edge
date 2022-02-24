namespace MEdge.Core
{
    using System;



    public readonly struct name : IEquatable<name>
    {
        public readonly String Value;
        public name(String v) => Value = v;
        public static implicit operator String(name v) => v.Value;
        public static implicit operator string(name v) => v.Value.ToString();
        public static implicit operator name(String v) => new name(v);
        public static implicit operator name(string v) => new name(v);

        public bool Equals( name other ) => other == this;
        public override bool Equals( object? obj ) => Value.Equals( obj );
        public override int GetHashCode()
        {
            var aV = Value;
            var aN = string.Equals(aV, "", StringComparison.InvariantCultureIgnoreCase) || string.Equals(aV, "none", StringComparison.InvariantCultureIgnoreCase);
            return aN ? 1 : Value.GetHashCode();
        }



        public static bool operator ==( name a, name b )
        {
            var aV = a.Value;
            var bV = b.Value;
            if(string.Equals(aV, bV, StringComparison.InvariantCultureIgnoreCase))
                return true;
            var aN = string.Equals(aV, "", StringComparison.InvariantCultureIgnoreCase) || string.Equals(aV, "none", StringComparison.InvariantCultureIgnoreCase);
            var bN = string.Equals(bV, "", StringComparison.InvariantCultureIgnoreCase) || string.Equals(bV, "none", StringComparison.InvariantCultureIgnoreCase);
            return aN && bN;
        }



        public static bool operator !=(name a, name b) => (a == b) == false;
        public override string ToString() => Value.ToString();
    }
}