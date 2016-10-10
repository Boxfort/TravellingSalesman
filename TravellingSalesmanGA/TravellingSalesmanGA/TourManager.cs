using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanGA
{
    /*  
     *  Class with static methods which can be accessed easily 
     *  by all of the tours which require information regarding cities.
     */
    class TourManager
    {
        private static List<City> citiesList = new List<City>();

        public static void addCity(City city)
        {
            citiesList.Add(city);
        }

        public static City getCity(int index)
        {
            return citiesList[index];
        }

        public static int numberOfCities()
        {
            return citiesList.Count();
        }
    }
}
