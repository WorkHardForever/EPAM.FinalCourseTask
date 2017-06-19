using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.ORM.Entities;

namespace ProjectManagement.DAL.Mappers
{
    public static class DbPersonMapper
    {
        public static DalPerson ToDalPerson(this Person dbPerson)
        {
            return new DalPerson()
            {
                Id = dbPerson.Id,
                Name = dbPerson.Name,
                Surname = dbPerson.Surname,
                GivenTasks = dbPerson.GivenTasks?.ToDalTaskEnumerable(),
                ReceivedTasks = dbPerson.ReceivedTasks?.ToDalTaskEnumerable()
            };
        }

        public static Person ToDbPerson(this DalPerson dalPerson)
        {
            return new Person()
            {
                Id = dalPerson.Id,
                Name = dalPerson.Name,
                Surname = dalPerson.Surname,
                GivenTasks = dalPerson.GivenTasks?.ToDbTaskCollection(),
                ReceivedTasks = dalPerson.ReceivedTasks?.ToDbTaskCollection()
            };
        }
    }
}
