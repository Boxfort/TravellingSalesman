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
