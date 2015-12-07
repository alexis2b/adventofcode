namespace day07.Impl
{
    internal sealed class LShiftGate : IGate
    {
        private readonly IGate _a;
        private readonly int _shift;

        public LShiftGate(IGate a, int shift)
        {
            _a = a;
            _shift = shift;
        }

        public ushort Value
        {
            get { return (ushort) ( _a.Value << _shift ); }
        }
    }
}
