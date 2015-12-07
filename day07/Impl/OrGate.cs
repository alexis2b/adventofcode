namespace day07.Impl
{
    internal sealed class OrGate : IGate
    {
        private readonly IGate _a;
        private readonly IGate _b;

        public OrGate(IGate a, IGate b)
        {
            _a = a;
            _b = b;
        }

        public ushort Value
        {
            get { return (ushort) ( _a.Value | _b.Value ); }
        }
    }
}
