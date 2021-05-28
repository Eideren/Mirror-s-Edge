namespace MEdge
{
    public class name
    {
        public readonly string Value;
        public name(string v) => Value = v;
        public static implicit operator string(name v) => v.Value;
        public static implicit operator name(string v) => new name(v);
        
        public override bool Equals(object? obj)
        {
            if (obj is string str)
                return Value == str;
            return obj is name n && n.Value == Value;
        }
        public override int GetHashCode() => Value != null ? Value.GetHashCode() : 0;
        
        public static bool operator ==(name a, name b) => ReferenceEquals(a, b) || a?.Value == b?.Value;
        public static bool operator !=(name a, name b) => (a == b) == false;
    }
}