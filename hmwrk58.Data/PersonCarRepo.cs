using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hmwrk58.Data
{
    public class PersonCarRepo
    {
        private readonly string _connectionString;

        public PersonCarRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetAll()
        {
            using var context = new PeopleDataContext(_connectionString);
            return context.People.Include(p => p.Cars).ToList();
        }
        
        public void AddPerson(Person person)
        {
            using var context = new PeopleDataContext(_connectionString);
            context.People.Add(person);
            context.SaveChanges();
        }

        public Person GetPersonById(int id)
        {
            using var context = new PeopleDataContext(_connectionString);
            return context.People.Where(p => p.Id == id).FirstOrDefault();
        }

        public void AddCar(Car car)
        {
            using var context = new PeopleDataContext(_connectionString);
            context.Cars.Add(car);
            context.SaveChanges();
        }
    }
}
