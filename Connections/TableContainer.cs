namespace Connections
{
    public class TableContainer
    {
        public string Name { get; set; }
        public int Ordinal { get; set; }
        public bool Visible { get; set; }
        public string Column { get; set; }
        public string DisplayText { get; set; }
        public string DataPropertyName { get; set; }
        public override string ToString() => $"({Name}) {Column}";

    }
}
