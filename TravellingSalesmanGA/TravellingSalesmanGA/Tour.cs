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
        private double _distance = 0;

        public Tour()
        {
            for(int i = 0; i < TourManager.numberOfCities(); i++)
            {
                _tour.Add(null);
            }
        }

        public Tour(List<City> tour)
        {
            _tour = tour;
        }

        //Copies list of cities from tour manager then shuffles them into a random order.
        public void generateRandomTour()
        {
            //TODO: Change this?
            for(int i = 0; i < TourManager.numberOfCities(); i++)
            {
                setCity(i, TourManager.getCity(i));
            }

            shuffleTour();
        }

        //Shuffles list into a random order.
        private void shuffleTour()
        {
            Random rand = new Random();

            for(int i = 0; i < _tour.Count(); i++)
            {
                int k = rand.Next(i + 1);
                City temp = _tour[k];
                _tour[k] = _tour[i];
                _tour[i] = temp;
            }
        }

        public bool containsCity(City city)
        {
            return _tour.Contains(city);
        }

        public double getDistance()
        {
            if (_distance == 0)
            {
                double tourDistance = 0;

                for(int i = 0; i < _tour.Count(); i++)
                {
                    //If we're at the end of the tour, go back to the first city.
                    int nextCity = (i + 1 < _tour.Count()) ? i : 0;

                    tourDistance += _tour[i].distanceTo(_tour[nextCity]);
                }

                return tourDistance;
            }

            return _distance;
        }

        public void setCity(int index, City city)
        {
            _tour[index] = city;

            //List has been modified, reset distance + fitness
            _distance = 0;
            _fitness = 0;
        }

        public City getCity(int index)
        {
            return _tour[index];
        }
    }
}
