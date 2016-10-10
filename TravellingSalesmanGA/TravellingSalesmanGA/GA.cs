using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanGA
{
    class GA
    {
        private static double _mutationRate = 0.015;
        private static int _tournamentSize = 5;
        private static bool _elitism = true;

        public static Population evolvePopulation(Population oldPopulation)
        {
            Population newPopulation = new Population(oldPopulation.populationCount());
            int offset = 0;

            if(_elitism)
            {
                newPopulation.addTour(0, oldPopulation.getFittest());
                offset = 1;
            }

            for(int i = offset; i < newPopulation.populationCount(); i++)
            {
                Tour parent1 = tournamentSelection(oldPopulation);
                Tour parent2 = tournamentSelection(oldPopulation);

                Tour child = crossover(parent1, parent2);

                newPopulation.addTour(i, child);
            }

            for(int i = offset; i < newPopulation.populationCount(); i++)
            {
                newPopulation.addTour(i, mutate(newPopulation.getTour(i)));
            }

            return newPopulation;
        }

        private static Tour mutate(Tour tour)
        {
            //TODO: Only beneficial mutations ?

            Random rand = new Random(DateTime.Now.Millisecond);

            for(int i = 0; i < tour.tourSize(); i++)
            {
                //If mutation then swap two random cities in the tour.
                if (rand.NextDouble() < _mutationRate)
                {
                    int j = (int)rand.NextDouble() * tour.tourSize();

                    City city1 = tour.getCity(i);
                    City city2 = tour.getCity(j);

                    tour.setCity(i, city2);
                    tour.setCity(j, city1);
                }
            }

            return tour;
        }

        //Takes a set of parents and creates a child tour.
        private static Tour crossover(Tour parent1, Tour parent2)
        {
            Tour child = new Tour();
            Random rand = new Random(DateTime.Now.Millisecond);

            int startPos = rand.Next(0, parent1.tourSize());
            int endPos = rand.Next(0, parent1.tourSize());

            //Swap the positions.
            if (startPos > endPos)
            {
                int temp = startPos;
                startPos = endPos;
                endPos = temp;
            }

            //Add a random portion of parents1's tour to the child.
            for(int i = startPos; i < endPos; i++)
            {
                child.setCity(i, parent1.getCity(i));
            }

            //Add the remaining cities in the tour from parent2, in the order they appear
            for(int i = 0; i < parent2.tourSize(); i++)
            {
                if(!child.containsCity(parent2.getCity(i)))
                {
                    for (int j = 0; j < child.tourSize(); j++)
                    {
                        // Spare position found, add city
                        if (child.getCity(j) == null)
                        {
                            child.setCity(j, parent2.getCity(i));
                            break;
                        }
                    }
                }
            }

            return child;
        }

        private static Tour tournamentSelection(Population population)
        {
            Population tournament = new Population();

            //Fill the tournament population with random tours from the given population
            //If the tournament size is larger, weak individuals have a smaller chance to be selected.
            for (int i = 0; i < _tournamentSize; i++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                tournament.addTour(i, population.getTour(rand.Next(0, population.populationCount())));
            }

            return tournament.getFittest();
        }

        public static double MutationRate
        {
            get { return _mutationRate; }
            set
            {
                if (value <= 1 && value >= 0)
                {
                    _mutationRate = value;
                }
            }
        }

        public static int TournamentSize
        {
            get { return _tournamentSize; }
            set
            {
                if (value <= TourManager.numberOfCities() && value > 0)
                {
                    _tournamentSize = value;
                }
            }
        }

        public static bool Elitism
        {
            get { return _elitism; }
            set { _elitism = value; }
        }
    }
}
