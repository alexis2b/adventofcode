using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day07
{
    using Impl;
    using System.Diagnostics;

    internal sealed class CircuitBuilder
    {
        private readonly Dictionary<string, IGate> _gates;

        public CircuitBuilder()
        {
            _gates = new Dictionary<string, IGate>();
        }

        public void AddConnection(string name, string ops, string term1, string term2)
        {

            switch (ops)
            {
                case ""      : AddConstant(name, term1); break;
                case "NOT"   : AddNot(name, term2); break;
                case "AND"   : AddAnd(name, term1, term2); break;
                case "OR"    : AddOr(name, term1, term2); break;
                case "RSHIFT": AddRShift(name, term1, term2); break;
                case "LSHIFT": AddLShift(name, term1, term2); break;
                default:
                    Debug.Fail("unknown ops: " + ops);
                    break;
            }
        }

        public void Override(string name, ushort value)
        {
            _gates.Remove(name);
            _gates.Add(name, new ConstantGate(value));
        }

        public void ResetWires()
        {
            foreach (var gateNameAndValue in _gates)
            {
                var gateCache = gateNameAndValue.Value as GateResultCache;
                if (gateCache != null)
                {
                    Debug.WriteLine("Resetting gate " + gateNameAndValue.Key);
                    gateCache.Reset();
                }
            }
        }

        public IDictionary<string, IGate> GetCircuit()
        {
            return _gates;
        }


        private void AddConstant(string name, string term1)
        {
            _gates.Add(name, GetInput(term1) );
        }

        private void AddAnd(string name, string term1, string term2)
        {
            _gates.Add(name, new GateResultCache(new AndGate(GetInput(term1), GetInput(term2))));
        }

        private void AddOr(string name, string term1, string term2)
        {
            _gates.Add(name, new GateResultCache(new OrGate(GetInput(term1), GetInput(term2))));
        }

        private void AddNot(string name, string term1)
        {
            _gates.Add(name, new GateResultCache(new NotGate(GetInput(term1))));
        }

        private void AddRShift(string name, string term1, string term2)
        {
            _gates.Add(name, new GateResultCache(new RShiftGate(GetInput(term1), ushort.Parse(term2))));
        }

        private void AddLShift(string name, string term1, string term2)
        {
            _gates.Add(name, new GateResultCache(new LShiftGate(GetInput(term1), ushort.Parse(term2))));
        }

        private IGate GetInput(string term)
        {
            ushort constant;
            if (ushort.TryParse(term, out constant))
                return new ConstantGate(constant);
            else
                return new NamedGate(_gates, term);
        }
    }
}
