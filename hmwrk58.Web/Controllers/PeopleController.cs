using hmwrk58.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hmwrk58.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [Route("getall")]
        [HttpGet]
        public List<Person> GetAll()
        {
            var repo = new PersonCarRepo(_connectionString);
            List<Person> people = repo.GetAll();
            return people;
        }
        [Route("addperson")]
        [HttpPost]
        public void AddPerson(Person person)
        {
            var repo = new PersonCarRepo(_connectionString);
            repo.AddPerson(person);
        }
        [Route("getpersonbyid")]
        [HttpGet]
        public Person GetPerson(int id)
        {
            var repo = new PersonCarRepo(_connectionString);
            return repo.GetPersonById(id);
        }
        [Route("addcar")]
        [HttpPost]
        public void AddCar(Car car)
        {
            var repo = new PersonCarRepo(_connectionString);
            repo.AddCar(car);
        }
    }
}
