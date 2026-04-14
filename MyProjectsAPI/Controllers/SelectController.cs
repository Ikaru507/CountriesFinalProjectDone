using Microsoft.AspNetCore.Mvc;
using ViewModel;
using Model;

namespace MyProjectsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        [HttpGet]
        [ActionName("CountriesSelector")]

        public CountriesList SelectAllCountries()
        {
           CountriesDB countriesDB = new CountriesDB();
            CountriesList countriesList = countriesDB.SelectAll();
            return countriesList;
        }
        [HttpPost]
        public int InsertCountry([FromBody] Countries country)
        {
            CountriesDB countriesDB = new CountriesDB();
            countriesDB.Insert(country);
            int x = countriesDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteCountry(int id)
        {
            CountriesDB countriesDB = new CountriesDB();
            Countries country = countriesDB.SelectById(id);
            countriesDB.Delete(country);
            int x = countriesDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateCountry([FromBody] Countries country)
        {
            CountriesDB countriesDB = new CountriesDB();
            countriesDB.Update(country);
            int x = countriesDB.SaveChanges();
        }


        [HttpGet]
        [ActionName("ContinentsSelector")]

        public ContinentsList SelectAllContinents()
        {
            ContinentsDB continentsDB = new ContinentsDB();
            ContinentsList continentsList = continentsDB.SelectAll();
            return continentsList;
        }
        [HttpPost]
        public int InsertContinent([FromBody] Continents Continent)
        {
            ContinentsDB continentsDB = new ContinentsDB();
            continentsDB.Insert(Continent);
            int x = continentsDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteContinent(int id)
        {
            ContinentsDB continentsDB = new ContinentsDB();
            Continents continent = continentsDB.SelectById(id);
            continentsDB.Delete(continent);
            int x = continentsDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateContinent([FromBody] Continents continent)
        {
            ContinentsDB continentsDB = new ContinentsDB();
            continentsDB.Update(continent);
            int x = continentsDB.SaveChanges();
        }

        [HttpGet]
        [ActionName("LanguagesSelector")]

        public LanguagesList SelectAllLanguages()
        {
            LanguagesDB languagesDB = new LanguagesDB();
            LanguagesList languagesList = languagesDB.SelectAll();
            return languagesList;
        }
        [HttpPost]
        public int InsertLanguage([FromBody] Languages Language)
        {
            LanguagesDB languagesDB = new LanguagesDB();
            languagesDB.Insert(Language);
            int x = languagesDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteLanguages(int id)
        {
            LanguagesDB languagesDB = new LanguagesDB();
            Languages Language = languagesDB.SelectById(id);
            languagesDB.Delete(Language);
            int x = languagesDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateLanguages([FromBody] Languages Language)
        {
            LanguagesDB languagesDB = new LanguagesDB();
            languagesDB.Update(Language);
            int x = languagesDB.SaveChanges();
        }

        [HttpGet]
        [ActionName("WeatherSelector")]

        public WeatherList SelectAllWeather()
        {
            WeatherDB weatherDB = new WeatherDB();
            WeatherList weatherList = weatherDB.SelectAll();
            return weatherList;
        }

        [HttpPost]
        public int InsertWeather([FromBody] Weather weather)
        {
            WeatherDB weatherDB = new WeatherDB();
            weatherDB.Insert(weather);
            int x = weatherDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteWeather(int id)
        {
            WeatherDB weatherDB = new WeatherDB();
            Weather weather = weatherDB.SelectById(id);
            weatherDB.Delete(weather);
            int x = weatherDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateWeather([FromBody] Weather weather)
        {
            WeatherDB weatherDB = new WeatherDB();
            weatherDB.Update(weather);
            int x = weatherDB.SaveChanges();
        }



        [HttpGet]
        [ActionName("UserDetailsSelector")]

        public UserDetailsList SelectAllUserDetails()
        {
            UserDetailsDB userDetailsDB = new UserDetailsDB();
            UserDetailsList userDetailsList = userDetailsDB.SelectAll();
            return userDetailsList;
        }

        [HttpPost]
        [ActionName("InsertUserDetails")]
        public int InsertUserDetails([FromBody] UserDetails userDetails)
        {
            UserDetailsDB userDetailsDB = new UserDetailsDB();
            userDetailsDB.Insert(userDetails);
            int x = userDetailsDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteUserDetails(int id)
        {
            UserDetailsDB userDetailsDB = new UserDetailsDB();
            UserDetails userDetails = userDetailsDB.SelectById(id);
            userDetailsDB.Delete(userDetails);
            int x = userDetailsDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateUserDetails([FromBody] UserDetails userDetails)
        {
            UserDetailsDB userDetailsDB = new UserDetailsDB();
            userDetailsDB.Update(userDetails);
            int x = userDetailsDB.SaveChanges();
        }



        [HttpGet]
        [ActionName("CategorySelector")]

        public CategoryList SelectAllCategory()
        {
            CategoryDB categoryDB = new CategoryDB();
            CategoryList categoryList = categoryDB.SelectAll();
            return categoryList;
        }

        [HttpPost]
        public int InsertCategory([FromBody] Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            categoryDB.Insert(category);
            int x = categoryDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteCategory(int id)
        {
            CategoryDB categoryDB = new CategoryDB();
            Category category = categoryDB.SelectById(id);
            categoryDB.Delete(category);
            int x = categoryDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateCategory([FromBody] Category category)
        {
            CategoryDB categoryDB = new CategoryDB();
            categoryDB.Update(category);
            int x = categoryDB.SaveChanges();
        }



        [HttpGet]
        [ActionName("AttractionsSelector")]

        public AttractionsList SelectAllAttractions()
        {
            AttractionsDB attractionsDB = new AttractionsDB();
            AttractionsList attractionsList = attractionsDB.SelectAll();
            return attractionsList;
        }

        [HttpPost]
        public int InsertAttractions([FromBody] Attractions attraction)
        {
            AttractionsDB attractionsDB = new AttractionsDB();
            attractionsDB.Insert(attraction);
            int x = attractionsDB.SaveChanges();
            return x;

        }

        [HttpDelete("{id}")]
        public int DeleteAttractions(int id)
        {
            AttractionsDB attractionsDB = new AttractionsDB();
            Attractions attraction = attractionsDB.SelectById(id);
            attractionsDB.Delete(attraction);
            int x = attractionsDB.SaveChanges();
            return x;
        }

        [HttpPut]
        public void UpdateAttractions([FromBody] Attractions attraction)
        {
            AttractionsDB attractionsDB = new AttractionsDB();
            attractionsDB.Update(attraction);
            int x = attractionsDB.SaveChanges();
        }


        // --- VisitedCountries ---
        [HttpGet]
        [ActionName("VisitedCountriesSelector")]
        public VisitedCountriesList SelectAllVisitedCountries()
        {
            VisitedCountriesDB db = new VisitedCountriesDB();
            return db.SelectAll();
        }
        [HttpPost]
        public int InsertVisitedCountries([FromBody] VisitedCountries vc)
        {
            VisitedCountriesDB db = new VisitedCountriesDB();
            db.Insert(vc);
            return db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public int DeleteVisitedCountries(int id)
        {
            VisitedCountriesDB db = new VisitedCountriesDB();
            var item = db.SelectById(id);
            if (item != null) { db.Delete(item); return db.SaveChanges(); }
            return 0;
        }

        // --- UserProfile ---
        [HttpGet]
        [ActionName("UserProfileSelector")]
        public UserProfileList SelectAllUserProfiles()
        {
            UserProfileDB db = new UserProfileDB();
            return db.SelectAll();
        }
        [HttpPost]
        public int InsertUserProfile([FromBody] UserProfile profile)
        {
            UserProfileDB db = new UserProfileDB();
            return db.Insert(profile); // מחזיר int ישירות
        }
        [HttpPut]
        public int UpdateUserProfile([FromBody] UserProfile profile)
        {
            UserProfileDB db = new UserProfileDB();
            return db.Update(profile); // מחזיר int ישירות
        }

        // --- Languages_Countries ---
        [HttpGet]
        [ActionName("LanguagesCountriesSelector")]
        public Languages_CountriesList SelectAllLanguages_Countries()
        {
            LanguagesCountriesDB db = new LanguagesCountriesDB();
            return db.SelectAll();
        }
        [HttpPost]
        public int InsertLanguages_Countries([FromBody] Languages_Countries lc)
        {
            LanguagesCountriesDB db = new LanguagesCountriesDB();
            db.Insert(lc);
            return db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public int DeleteLanguages_Countries(int id)
        {
            LanguagesCountriesDB db = new LanguagesCountriesDB();
            var item = db.SelectById(id);
            if (item != null) { db.Delete(item); return db.SaveChanges(); }
            return 0;
        }

        // --- Weather_Countries ---
        [HttpGet]
        [ActionName("WeatherCountriesSelector")]
        public Weather_CountriesList SelectAllWeather_Countries()
        {
            WeatherCountriesDB db = new WeatherCountriesDB();
            return db.SelectAll();
        }
        [HttpPost]
        public int InsertWeather_Countries([FromBody] Weather_Countries wc)
        {
            WeatherCountriesDB db = new WeatherCountriesDB();
            db.Insert(wc);
            return db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public int DeleteWeather_Countries(int id)
        {
            WeatherCountriesDB db = new WeatherCountriesDB();
            var item = db.SelectById(id);
            if (item != null) { db.Delete(item); return db.SaveChanges(); }
            return 0;
        }


    }
    //    {
    //        public IActionResult Index()
    //        {
    //            return View();
    //        }
    //    }
}
