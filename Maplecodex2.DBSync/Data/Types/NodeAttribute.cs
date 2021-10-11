namespace Maplecodex2.DBSync.Data.Types
{
    public class NodeAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; } // This can be an array of values so we store as a string until figure out.
        public Type TypeOf { get; set; }

        public NodeAttribute()
        {
            Name = "attribute";
            Value = "value";
            TypeOf = typeof(string);
        }

        public NodeAttribute(string name, string value)
        {
            Name = name;
            Value = value;
            TypeOf = typeof(string);
        }

        public override string ToString() => $"Name: {Name}, Value: {Value}";
    }
}