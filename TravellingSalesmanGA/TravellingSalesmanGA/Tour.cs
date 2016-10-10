using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanGA
{
    class Tour
    {
        //Holds each traversal between cities
        private List<City> _tour = new List<City>();

        private double _fitness = 0;
        private int _distance = 0;

        public Tour(int numCities)
        {
            for(int i = 0; i < numCities; i++)
            {
                _tour.Add(null);
            }
        }

        public Tour(List<City> tour)
        {
            _tour = tour;
        }

        public void setCity(int index, City city)
        {
            _tour[index] = city;
        }

        public City getCity(int index)
        {
            return _tour[index];
        }
    }
}
