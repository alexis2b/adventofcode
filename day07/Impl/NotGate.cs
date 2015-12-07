namespace day07.Impl
{
    internal sealed class NotGate : IGate
    {
        private readonly IGate _a;

        public NotGate(IGate a)
        {
            _a = a;
        }

        public ushort Value
        {
            get { return (ushort) ( ~_a.Value ); }
        }
    }
}
