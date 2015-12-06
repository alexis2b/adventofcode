using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day03
{
    internal sealed class House : IEquatable<House>
    {
        private readonly int _x;
        private readonly int _y;

        public House(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public bool Equals(House other)
        {
            return other != null && other._x == _x && other._y == _y;
        }

        public override bool  Equals(object obj)
        {
            return Equals(obj as House);
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("House({0},{1})", _x, _y);
        }
    }
}
