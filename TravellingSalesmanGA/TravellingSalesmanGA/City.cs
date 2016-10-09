using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanGA
{
    class City
    {
        private int _x, _y;

        //Generate random x and y value for city.
        public City()
        {
            Random rand = new Random();
            _x = rand.Next(0, 100);
            _y = rand.Next(0, 100);
        }

        public City(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y;  }
        }
    }
}
