namespace day07.Impl
{
    internal sealed class RShiftGate : IGate
    {
        private readonly IGate _a;
        private readonly int _shift;

        public RShiftGate(IGate a, int shift)
        {
            _a = a;
            _shift = shift;
        }

        public ushort Value
        {
            get { return (ushort) ( _a.Value >> _shift ); }
        }
    }
}
