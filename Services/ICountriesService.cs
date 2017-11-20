using System.Collections.Generic;
using Entities;

namespace Services
{
    public interface ICountriesService
    {
        CountryEntity GetCountry(int contryId);

        void SaveCountry(CountryEntity country);

        IEnumerable<CountryEntity> GetCountries();
    }
}
