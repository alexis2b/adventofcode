using System.Collections.Generic;
using System.Diagnostics;

namespace day07.Impl
{
    internal sealed class NamedGate : IGate
    {
        private readonly Dictionary<string, IGate> _gates;
        private readonly string _gateName;

        public NamedGate(Dictionary<string, IGate> gates, string gateName)
        {
            Debug.Assert(!string.IsNullOrEmpty(gateName));
            _gates = gates;
            _gateName = gateName;
        }

        public ushort Value
        {
            get
            {
                return _gates[_gateName].Value;
            }
        }
    }
}
