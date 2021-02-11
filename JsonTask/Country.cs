using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace JsonTask
{
    public class Country
    {
        public string Name { get; }

        public string Region { get; }

        public string SubRegion { get; }

        public List<Currency> Currencies { get; }

        public double Population { get; }

        public string Capital { get; }

        public Country(string name, string region, string subRegion, double population, string capital, List<Currency> currencies)
        {
            Name = name;
            Region = region;
            SubRegion = subRegion;
            Population = population;
            Capital = capital;
            Currencies = currencies;
        }

        public override string ToString()
        {
            return $"{Name} - {Capital}";
        }
    }
}