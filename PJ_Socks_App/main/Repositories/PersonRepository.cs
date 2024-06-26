﻿using PJ_Socks_App.main.DBContext;
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
            var existingPerson = context.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                MessageBox.Show("Đã tồn tại");
            }
            else {
                context.Persons.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }

        public void update(Person person)
        {
            var existingPerson = context.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson == null)
            {
                insert(person);
            }
            else
            {
                existingPerson.Name = person.Name;
                existingPerson.Role = person.Role;
                existingPerson.Email = person.Email;
                existingPerson.Phone = person.Phone;
                existingPerson.Status = person.Status;

                context.SubmitChanges();
            }
        }

        public void delete(int PersonId)
        {
            var person = context.Persons.FirstOrDefault(p => p.Id.Equals(p.Id));
            context.Persons.DeleteOnSubmit(person);
            context.SubmitChanges();
        }

        public List<Person> FindPersonsByName(string searchQuery)
        {
            var persons = (from p in context.Persons
                           where p.Name.Contains(searchQuery)
                           select p).ToList();

            return persons;
        }


    }
}
