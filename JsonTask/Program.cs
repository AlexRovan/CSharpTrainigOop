using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace JsonTask
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                const string region = "americas";

                var countries = JsonConvert.DeserializeObject<List<Country>>(GetJsonDataCountries(region));

                Console.WriteLine($"Информация о регионе: {region}");
                Console.WriteLine($"Население: {GetRegionPopulationCount(countries)}");

                var currencies = GetCountriesCurrencies(countries);

                Console.WriteLine("Действующие валюты:");
                foreach (var currency in currencies)
                {
                    Console.WriteLine(currency);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка выполнения программы: {e}");
            }
        }

        public static double GetRegionPopulationCount(List<Country> countries)
        {
            return countries.Sum(p => p.Population);
        }

        public static List<Currency> GetCountriesCurrencies(List<Country> countries)
        {
            return countries.SelectMany(p => p.Currencies).Distinct(new CurrencyComparer()).ToList();
        }

        public static string GetJsonDataCountries(string region)
        {
            try
            {
                string stringResponse;
                var request = WebRequest.Create($"https://restcountries.eu/rest/v2/region/{region}");
                var response = request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    using var reader = new StreamReader(stream);
                    stringResponse = reader.ReadToEnd();
                }

                response.Close();
                return stringResponse;
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Ошибка выполнения запроса: {ex}");
                throw;
            }
        }
    }
}