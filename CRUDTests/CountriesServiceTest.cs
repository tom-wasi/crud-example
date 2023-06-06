using ServiceContracts;
using Entities;
using Services;
using ServiceContracts.DTO;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }
        //When CountryAddRequest is null, it should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });
        }

        //When CountryName is null, it should throw ArgumentException

        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null};

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
            //Act
                _countriesService.AddCountry(request);
            });
        }

        //When CountryName is duplicate, it should throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "USA" };

            //Assert
            Assert.Throws<ArgumentException>(() =>
                {
                    //Act
                    _countriesService.AddCountry(request1);
                    _countriesService.AddCountry(request2);
                });
        }

            //When you supply proper CountryName, it should add the country to the existing country list
            [Fact]
            public void AddCountry_ProperCountryDetails()
            {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Japan" };

            //Act
            CountryResponse countryResponse = _countriesService.AddCountry(request);
            
            //Assert
            Assert.True(countryResponse.CountryID != Guid.Empty);
        }
    }
}

