using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace Service
{
    public interface IAPIService
    {
        public Task<CountriesList> GetAllCountries();
        public Task<int> InsertCountry(Countries country);
        public Task<int> UpdateCountry(Countries country);
        public Task<int> DeleteCountry(int id);


        public Task<ContinentsList> GetAllContinents();
        public Task<int> InsertContinent(Continents continent);
        public Task<int> UpdateContinent(Continents continent);
        public Task<int> DeleteContinent(int id);
          

        public Task<LanguagesList> GetAllLanguages();
        public Task<int> InsertLanguage(Languages language);
        public Task<int> UpdateLanguage(Languages language);
        public Task<int> DeleteLanguage(int id);


        public Task<WeatherList> GetAllWeather();
        public Task<int> InsertWeather(Weather weather);
        public Task<int> UpdateWeather(Weather weather);
        public Task<int> DeleteWeather(int id);


        public Task<UserDetailsList> GetAllUserDetails();
        public Task<int> InsertUserDetails(UserDetails userDetails);
        public Task<int> UpdateUserDetails(UserDetails userDetails);
        public Task<int> DeleteUserDetails(int id);


        public Task<CategoryList> GetAllCategory();
        public Task<int> InsertCategory(Category category);
        public Task<int> UpdateCategory(Category category);
        public Task<int> DeleteCategory(int id);


        public Task<AttractionsList> GetAllAttractions();
        public Task<int> InsertAttraction(Attractions attraction);
        public Task<int> UpdateAttraction(Attractions attraction);
        public Task<int> DeleteAttraction(int id);

        // --- VisitedCountries ---
        Task<VisitedCountriesList> GetAllVisitedCountries();
        Task<int> InsertVisitedCountries(VisitedCountries vc);
        Task<int> DeleteVisitedCountries(int id);

        // --- UserProfile ---
        Task<UserProfileList> GetAllUserProfiles();
        Task<int> InsertUserProfile(UserProfile profile);
        Task<int> UpdateUserProfile(UserProfile profile);

        // --- Languages_Countries ---
        Task<Languages_CountriesList> GetAllLanguages_Countries();
        Task<int> InsertLanguages_Countries(Languages_Countries lc);
        Task<int> DeleteLanguages_Countries(int id);

        // --- Weather_Countries ---
        Task<Weather_CountriesList> GetAllWeather_Countries();
        Task<int> InsertWeather_Countries(Weather_Countries wc);
        Task<int> DeleteWeather_Countries(int id);
    }
}
