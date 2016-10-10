using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanGA
{
    class Population
    {
        private List<Tour> _tours = new List<Tour>();

        public Population() { }

        public Population(int populationSize)
        {
            for(int i = 0; i < populationSize; i++)
            {
                Tour tour = new Tour();
                tour.generateRandomTour();
                _tours.Add(tour);
            }
        }
 
        public void addTour(int index, Tour tour)
        {
            _tours[index] = tour;
        }

        public Tour getTour(int index)
        {
            return _tours[index];
        }

        public Tour getFittest()
        {
            Tour fittest = _tours[0];

            for(int i = 1; i < _tours.Count(); i++)
            {
                if(fittest.getDistance() <= _tours[i].getDistance())
                {
                    fittest = getTour(i);
                }
            }

            return fittest;
        }

        public int populationCount()
        {
            return _tours.Count();
        }
    }
}
