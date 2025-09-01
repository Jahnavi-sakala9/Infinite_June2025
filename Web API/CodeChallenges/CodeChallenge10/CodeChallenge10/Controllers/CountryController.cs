using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeChallenge10.Models;

namespace CodeChallenge10.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "United States", Capital = "Washington, D.C." },
            new Country { ID = 3, CountryName = "United Kingdom", Capital = "London" },
            new Country { ID = 4, CountryName = "Canada", Capital = "Ottawa" },
            new Country { ID = 5, CountryName = "Australia", Capital = "Canberra" }
        };

        // GET
        public IHttpActionResult Get()
        {
            return Ok(countries);
        }

        // GET
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        // POST
        public IHttpActionResult Post([FromBody] Country country)
        {
            country.ID = countries.Max(c => c.ID) + 1; //auto increment
            countries.Add(country);
            return Created($"api/country/{country.ID}", country);
        }

        // PUT
        public IHttpActionResult Put(int id, [FromBody] Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return Ok(country);
        }

        // DELETE
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();

            countries.Remove(country);
            return Ok();
        }
    }
}



