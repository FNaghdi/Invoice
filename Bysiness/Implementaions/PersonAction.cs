
using Domain.Model;
using Business.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Business.DTOs.Person;

namespace WebApplication5.Implementaions
{
    public class PersonAction : IPersonAction
    {
        PersonContext _personContext;
        public PersonAction(PersonContext personContext)
        {
            _personContext= personContext;
        }
        public void Delete(int id)
        {
            var person = _personContext.people.FirstOrDefault(p => p.ID == id);
            if (person != null)
            {
                _personContext.people.Remove(person);
                _personContext.SaveChanges();
            }
        }

        public List<PersonInfo> GetPeople()
        {
            var q = from i in _personContext.people
                    select new PersonInfo
                    {
                    ID= i.ID,
                    FirstName=i.FirstName,
                    LastName=i.LastName,
                    Age=i.Age,
                    FullName=i.FirstName+" "+i.LastName,
                    };


          var list=  q.ToList();
            return list;
        }

        public Person GetPersonById(int id)
        {
            var person = _personContext.people.FirstOrDefault(p => p.ID == id);
            return person;
        }

        public void Save(PersonModel person)
        {
            Person p = new Person();
            p.Age = person.Age;
            p.FirstName = person.FirstName;
            p.LastName=person.LastName;
            _personContext.people.Add(p);
            _personContext.SaveChanges();
        }

        public void Update(Person person)
        {
            var _person = _personContext.people.FirstOrDefault(p => p.ID == person.ID);
            _person.FirstName= person.FirstName;
            _person.LastName= person.LastName;
            _person.Age= person.Age;
            _personContext.SaveChanges();
        }
    }
}
