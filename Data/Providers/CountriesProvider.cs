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

        public CountryDb GetById(int contryId)
        {
            return _unitOfWork.Repository<CountryDb>()
                .FindAll()
                .FirstOrDefault(q => q.CountryId == contryId);
        }

        public IEnumerable<CountryDb> GetAll()
        {
            return _unitOfWork.Repository<CountryDb>().FindAll();
        }

        public void Save(CountryDb country)
        {
            _unitOfWork.Repository<CountryDb>().Add(country);
        }
    }
}
