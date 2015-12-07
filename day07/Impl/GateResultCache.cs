using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace day07.Impl
{
    internal sealed class GateResultCache : IGate
    {
        private readonly IGate _gate;
        private ushort? _cachedValue;

        public GateResultCache(IGate gate)
        {
            _gate = gate;
        }

        public ushort Value
        {
            get
            {
                return (ushort)(_cachedValue ?? (_cachedValue = _gate.Value));
            }
        }

        public void Reset()
        {
            _cachedValue = null;
        }
    }
}
