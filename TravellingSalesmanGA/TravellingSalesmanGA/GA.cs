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
            }
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
    }
}
