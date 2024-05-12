using PJ_Socks_App.main.DBContext;
using PJ_Socks_App.main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PJ_Socks_App.main.Repositories
{
    public class PersonRepository
    {
        private readonly SockSalesDataContext context;

        public PersonRepository()
        {
            context = SockSalesDataContext.GetInstance();
        }

        public List<Person> GetUsers()
        {
            var users = context.Persons.Where(p => p.Role == "user").ToList();

            return users;
        }

        public Person Get(int id)
        {
            var person = context.Persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public void insert(Person person)
        {
            context.Persons.InsertOnSubmit(person);
            context.SubmitChanges();
        }

        public void update(Person person)
        {
            var updatedperson = context.Persons.FirstOrDefault(p => p.Id.Equals(person.Id));
            if (updatedperson == null)
            {
                MessageBox.Show("Người dùng chưa có trong database");
                insert(person);
                
            }
            else{context.Persons.Attach(person);
                context.SubmitChanges();
            }
        }

        public void delete(int PersonId)
        {
            var person = context.Persons.FirstOrDefault(p => p.Id.Equals(p.Id));
            context.Persons.DeleteOnSubmit(person);
            context.SubmitChanges();
        }

    }
}
