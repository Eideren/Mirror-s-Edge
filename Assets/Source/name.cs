namespace MEdge.Core
{
    public readonly struct name
    {
        public readonly String Value;
        public name(String v) => Value = v;
        public static implicit operator String(name v) => v.Value;
        public static implicit operator string(name v) => v.Value.ToString();
        public static implicit operator name(String v) => new name(v);
        public static implicit operator name(string v) => new name(v);

        public override bool Equals( object? obj ) => Value.Equals( obj );
        public override int GetHashCode() => Value.GetHashCode();
        public static bool operator ==(name a, name b) => a.Value == b.Value;
        public static bool operator !=(name a, name b) => (a == b) == false;
        public override string ToString() => Value.ToString();
    }
}