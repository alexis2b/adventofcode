namespace day07.Impl
{
    class ConstantGate : IGate
    {
        private readonly ushort _value;

        public ConstantGate(ushort value)
        {
            _value = value;
        }

        public ushort Value
        {
            get { return _value; }
        }
    }
}
