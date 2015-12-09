using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace day09
{
    internal sealed class Map
    {
        private readonly string[] _cities;
        private readonly int[,] _distances;

        public Map(IEnumerable<Distance> distances)
        {
            var distanceList = distances.ToList();
            _cities = distanceList.SelectMany(d => new[] { d.From, d.To }).Distinct().OrderBy(c => c).ToArray();
            _distances = new int[_cities.Length, _cities.Length];

            foreach (var distance in distanceList)
            {
                var i1 = IndexOf(distance.From);
                var i2 = IndexOf(distance.To);
                _distances[i1, i2] = _distances[i2, i1] = distance.Value;
            }

            DumpMap();
        }

        public IEnumerable<string> Cities { get { return _cities; } }

        public int DistanceBetween(string from, string to)
        {
            return _distances[IndexOf(from), IndexOf(to)];
        }

        private int IndexOf(string cityName)
        {
            return Array.IndexOf(_cities, cityName);
        }

        private void DumpMap()
        {
            Debug.Write(String.Format("{0,-13}", String.Empty));
            foreach (var city in _cities) Debug.Write(String.Format("{0,13}", city));
            Debug.WriteLine(string.Empty);

            for(var i = 0; i < _cities.Length; i++)
            {
                Debug.Write(String.Format("{0,-13}", _cities[i]));
                for(int j = 0; j < _cities.Length; j++)
                    Debug.Write(String.Format("{0,13}", _distances[i,j]));
                Debug.WriteLine(string.Empty);
            }
            Debug.WriteLine(string.Empty);
        }
    }
}
