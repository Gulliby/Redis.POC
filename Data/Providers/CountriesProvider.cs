using System.Collections.Generic;
using System.Linq;
using Data.Entities;

namespace Data.Providers
{
    public class CountriesProvider : ICountriesProvider
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountriesProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CountryDb GetCountry(int contryId)
        {
            return _unitOfWork.Repository<CountryDb>()
                .FindAll()
                .FirstOrDefault(q => q.CountryId == contryId);
        }

        public IEnumerable<CountryDb> GetCountries()
        {
            return _unitOfWork.Repository<CountryDb>().FindAll();
        }

        public int SaveCountry(CountryDb country)
        {
            var repository = _unitOfWork.Repository<CountryDb>();

            var entity = repository.Add(country);

            return entity.CountryId;
        }
    }
}
