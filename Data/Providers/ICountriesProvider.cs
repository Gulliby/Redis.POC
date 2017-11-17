using System.Collections.Generic;
using Data.Entities;

namespace Data.Providers
{
    public interface ICountriesProvider
    {
        int SaveCountry(CountryDb country);
        CountryDb GetCountry(int countryId);
        IEnumerable<CountryDb> GetCountries();
    }
}
