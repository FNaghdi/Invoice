

using Business.DTOs;
using Domain.Model;

namespace Business.Services
{
    public interface IPersonAction
    {
        void Save(PersonModel person);
        void Update(Person person);
        void Delete(int id);
        List<PersonInfo> GetPeople();

        Person GetPersonById(int id);
    }
}
