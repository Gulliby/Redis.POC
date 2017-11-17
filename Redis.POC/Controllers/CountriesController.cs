using System.Net.Http;
using Entities;
using Services;

namespace Redis.POC.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public HttpResponseMessage GetAll()
        {
            return Ok(_countriesService.GetCountries());
        }

        public HttpResponseMessage Get(int id)
        {
            return Ok(_countriesService.GetCountry(id));
        }

        public HttpResponseMessage Post(CountryEntity countryEntity)
        {
            return Ok(_countriesService.SaveCountry(countryEntity));
        }
    }
}