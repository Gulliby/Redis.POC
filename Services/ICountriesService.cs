using System.Collections.Generic;
using Entities;

namespace Services
{
    public interface ICountriesService
    {
        CountryEntity GetCountry(int contryId);

        int SaveCountry(CountryEntity country);

        IEnumerable<CountryEntity> GetCountries();
    }
}
