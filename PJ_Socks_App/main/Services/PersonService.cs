using PJ_Socks_App.main.Models;
using PJ_Socks_App.main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Services
{
    public class PersonService
    {
        private readonly PersonRepository personRepository;

        public PersonService()
        {
            personRepository = new PersonRepository();
        }

        public List<Person> GetUsers()
        {
            return personRepository.GetUsers();
        }

        public void insert(Person person)
        {
            personRepository.insert(person);
        }

        public void update(Person person) 
        {
            personRepository.update(person);
        }
            
        public void delete(int personId) 
        {
            personRepository.delete(personId);
        }

        public List<Person> FindByName(string name)
        {
            return personRepository.FindPersonsByName(name);
        }
    }
}
