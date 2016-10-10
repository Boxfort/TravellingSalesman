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

        //Calculate distance between this city and another.
        public double distanceTo(City city)
        {
            int xDistance = Math.Abs(_x - city.X);
            int yDistance = Math.Abs(_y - city.Y);

            return Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y;  }
            set { _y = value; }
        }
    }
}
