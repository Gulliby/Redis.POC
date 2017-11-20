using System.Collections.Generic;
using Data.Entities;

namespace Data.Providers
{
    public interface ICountriesProvider
    {
        void Save(CountryDb country);
        CountryDb GetById(int countryId);
        IEnumerable<CountryDb> GetAll();
    }
}
