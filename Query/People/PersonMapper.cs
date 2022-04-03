using Domain.People;
using Query.Financials;
using Query.People.DTOs;
using Query.Reports;
using Query.Schedules;

namespace Query.People
{
    public static class PersonMapper
    {
        public static PersonDto Map(this Person? person)
        {
            if(person == null)
                return new PersonDto();

            return new PersonDto()
            {
                Id = person.Id,
                CreationDate = person.CreationDate,
                Name = person.Name,
                Family = person.Family,
                NationalId = person.NationalId,
                BirthDate = person.BirthDate,
                Gender = person.Gender,
                ParentName = person.ParentName,
                Financials = person.Financials.ToList().Map(),
                Reports = person.Reports.ToList().Map(),
                Schedules = person.Schedules.ToList().Map(),
            };
        }

        public static ICollection<PersonDto> Map(this ICollection<Person> people)
        {
            var model = new List<PersonDto>();

            foreach (Person person in people)
            {
                model.Add(Map(person));
            }

            return model;
        }
    }
}
