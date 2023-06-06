using ServiceContracts.DTO;
using ServiceContracts;
using Entities;
namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countryList;
        public CountriesService()
        {
            _countryList = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //Validation: countryAddRequest parameter can't be null
            if(countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: countryAddRequest.CountryName parameter can't be null
            if(countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName should not exist already

            if(_countryList.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country already exists");
            }

            //Convert object from countryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //Generate new CountryID
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _countryList.Add(country);

            return country.ToCountryResponse();
        }
    }
}