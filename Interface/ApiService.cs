
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

    


namespace Service
{
    public class ApiService : IAPIService
    {
        string uri;
        public HttpClient client;
        public ApiService()
        {
            uri = "http://localhost:5038";
            client = new HttpClient();
        }
        public async Task<CountriesList> GetAllCountries()
        {
                                              
            return await client.GetFromJsonAsync<CountriesList>(uri + "/api/Select/CountriesSelector");  
        }

        public async Task<int> DeleteCountry(int id)
        {
            return (await client.DeleteAsync(uri+ $"/api/Select/DeleteCountry/{ id}")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCountry(Countries country)
        {
            return (await client.PutAsJsonAsync<Countries>(uri + "/api/Insert/UpdateCountry/", country)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCountry(Countries country)
        {
            return (await client.PostAsJsonAsync<Countries>(uri + "/api/Insert/InsertCountry/", country)).IsSuccessStatusCode ? 1 : 0;
        }




        public async Task<ContinentsList> GetAllContinents()
        {
            return await client.GetFromJsonAsync<ContinentsList>(uri + "/api/Select/ContinentsSelector");
        }

        public async Task<int> DeleteContinent(int id)
        {
            return (await client.DeleteAsync(uri+ $"/api/Select/DeleteContinent/{ id}")).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateContinent(Continents Continent)
        {
            return (await client.PutAsJsonAsync<Continents>(uri + "/api/Insert/UpdateContinent/", Continent)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertContinent(Continents Continent)
        {
            return (await client.PostAsJsonAsync<Continents>(uri + "/api/Insert/InsertContinent/", Continent)).IsSuccessStatusCode ? 1 : 0;
        }





        public async Task<LanguagesList> GetAllLanguages()
        {
            return await client.GetFromJsonAsync<LanguagesList>(uri + "/api/Select/LanguagesSelector");
        }

        public async Task<int> DeleteLanguage(int id)
        {
            return (await client.DeleteAsync(uri+ "/api/Select/DeleteLanguage/"+ id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateLanguage(Languages Language)
        {
            return (await client.PutAsJsonAsync<Languages>(uri + "/api/Insert/UpdateLanguage/", Language)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertLanguage(Languages Language)
        {
            return (await client.PostAsJsonAsync<Languages>(uri + "/api/Insert/InsertLanguage/", Language)).IsSuccessStatusCode ? 1 : 0;
        }






        public async Task<WeatherList> GetAllWeather()
        {
            return await client.GetFromJsonAsync<WeatherList>(uri + "/api/Select/WeatherSelector");
        }

        public async Task<int> DeleteWeather(int id)
        {
            return (await client.DeleteAsync(uri+ "/api/Select/DeleteWeather/"+ id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateWeather(Weather weather)
        {
            return (await client.PutAsJsonAsync<Weather>(uri + "/api/Insert/UpdateWeather/", weather)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertWeather(Weather weather)
        {
            return (await client.PostAsJsonAsync<Weather>(uri + "/api/Insert/InsertWeather/", weather)).IsSuccessStatusCode ? 1 : 0;
        }






        public async Task<UserDetailsList> GetAllUserDetails()
        {
            return await client.GetFromJsonAsync<UserDetailsList>(uri + "/api/Select/UserDetailsSelector");
        }

        public async Task<int> DeleteUserDetails(int id)
        {
            return (await client.DeleteAsync(uri+ "/api/Select/DeleteUserDetails/"+ id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateUserDetails(UserDetails userDetails)
        {
            return (await client.PutAsJsonAsync<UserDetails>(uri + "/api/Insert/UpdateUserDetails/", userDetails)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertUserDetails(UserDetails userDetails)
        {
            return (await client.PostAsJsonAsync<UserDetails>(uri + "/api/Insert/InsertUserDetails/", userDetails)).IsSuccessStatusCode ? 1 : 0;
        }







        public async Task<CategoryList> GetAllCategory()
        {
            return await client.GetFromJsonAsync<CategoryList>(uri + "/api/Select/CategorySelector");
        }

        public async Task<int> DeleteCategory(int id)
        {
            return (await client.DeleteAsync(uri+ "/api/Select/DeleteCategory/"+ id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return (await client.PutAsJsonAsync<Category>(uri + "/api/Insert/UpdateCategory/", category)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCategory(Category category)
        {
            return (await client.PostAsJsonAsync<Category>(uri + "/api/Insert/InsertCategory/", category)).IsSuccessStatusCode ? 1 : 0;
        }






        public async Task<AttractionsList> GetAllAttractions()
        {
            return await client.GetFromJsonAsync<AttractionsList>(uri + "/api/Select/AttractionsSelector");
        }

        public async Task<int> DeleteAttraction(int id)
        {
            return (await client.DeleteAsync(uri+ "/api/Select/DeleteAttraction/"+ id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAttraction(Attractions Attraction)
        {
            return (await client.PutAsJsonAsync<Attractions>(uri + "/api/Insert/UpdateAttraction/", Attraction)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertAttraction(Attractions Attraction)
        {
            return (await client.PostAsJsonAsync<Attractions>(uri + "/api/Insert/InsertAttraction/", Attraction)).IsSuccessStatusCode ? 1 : 0;
        }


        // --- VisitedCountries ---
        public async Task<VisitedCountriesList> GetAllVisitedCountries()
        {
            return await client.GetFromJsonAsync<VisitedCountriesList>(uri + "/api/Select/VisitedCountriesSelector");
        }
        public async Task<int> InsertVisitedCountries(VisitedCountries vc)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertVisitedCountries", vc)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteVisitedCountries(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteVisitedCountries/{id}")).IsSuccessStatusCode ? 1 : 0;
        }

        // --- UserProfile ---
        public async Task<UserProfileList> GetAllUserProfiles()
        {
            return await client.GetFromJsonAsync<UserProfileList>(uri + "/api/Select/UserProfileSelector");
        }
        public async Task<int> InsertUserProfile(UserProfile profile)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertUserProfile", profile)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateUserProfile(UserProfile profile)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateUserProfile", profile)).IsSuccessStatusCode ? 1 : 0;
        }

        // --- Languages_Countries ---
        public async Task<Languages_CountriesList> GetAllLanguages_Countries()
        {
            return await client.GetFromJsonAsync<Languages_CountriesList>(uri + "/api/Select/LanguagesCountriesSelector");
        }
        public async Task<int> InsertLanguages_Countries(Languages_Countries lc)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertLanguages_Countries", lc)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteLanguages_Countries(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteLanguages_Countries/{id}")).IsSuccessStatusCode ? 1 : 0;
        }

        // --- Weather_Countries ---
        public async Task<Weather_CountriesList> GetAllWeather_Countries()
        {
            return await client.GetFromJsonAsync<Weather_CountriesList>(uri + "/api/Select/WeatherCountriesSelector");
        }
        public async Task<int> InsertWeather_Countries(Weather_Countries wc)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertWeather_Countries", wc)).IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteWeather_Countries(int id)
        {
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteWeather_Countries/{id}")).IsSuccessStatusCode ? 1 : 0;
        }
    }
}
