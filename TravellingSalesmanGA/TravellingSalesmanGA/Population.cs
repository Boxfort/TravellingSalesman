using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanGA
{
    class Population
    {
        private List<Tour> tours = new List<Tour>();

        public Population(int populationSize)
        {
            for(int i = 0; i < populationSize; i++)
            {
                Tour tour = new Tour();
                tour.generateRandomTour();
                tours.Add(tour);
            }
        }
    }
}
