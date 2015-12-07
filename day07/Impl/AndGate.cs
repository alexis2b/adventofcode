namespace day07.Impl
{
    internal sealed class AndGate : IGate
    {
        private readonly IGate _a;
        private readonly IGate _b;

        public AndGate(IGate a, IGate b)
        {
            _a = a;
            _b = b;
        }

        public ushort Value
        {
            get { return (ushort) ( _a.Value & _b.Value ); }
        }
    }
}
