using Mark01.Core.DataObjects;
using Mark01.Core.ValueObjects;
using Newtonsoft.Json;

namespace Mark01.Core
{
    public class Person : Entities
    {
        /// <summary>
        /// Create a new PErson
        /// </summary>
        /// <param name="name">Person name</param>
        /// <param name="email">Adress email person valid</param>
        /// <param name="type">Type of person (PF or PJ)</param>
        public Person(string name, Email email, PersonType type)
        {
            Name = name;
            Email = email;
            Type = type;
        }

        public Person() { }

        public string Name { get; set; } = null!;
        public Email Email { get; } = null!;
        public PersonType Type { get; } = null!;

        public static implicit operator string(Person person) => person.ToString();

        public override string ToString()
        {
            var personDto = new PersonDto { Email = this.Email.Adress, Name = this.Name, Type = this.Type.Type };

            return JsonConvert.SerializeObject(personDto);
        }

        public static implicit operator Person(string personJson)
        {
            if (string.IsNullOrEmpty(personJson)) return new Person();

            PersonDto personDto = JsonConvert.DeserializeObject<PersonDto>(personJson);

            if (personDto == null) return new Person();

            return new Person(personDto.Name, new Email(personDto.Email), new PersonType(personDto.Type));
        }

        public static implicit operator Person(PersonDto personDto)
        {
            if (personDto == null) return new PersonDto();

            return new Person(personDto.Name, new Email(personDto.Email), new PersonType(personDto.Type));
        }
    }
}