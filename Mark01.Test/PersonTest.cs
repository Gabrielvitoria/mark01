using Mark01.Core;
using Mark01.Core.DataObjects;
using System;

namespace Mark01.Test
{
    public class PersonTest
    {
        [Fact(DisplayName = "1# Deve criar Instância de Person")]
        public void DeveCriarInstaciaDePerson()
        {
            var personValid = CreatePerson();
            Assert.True(personValid != null);
        }

        [Fact(DisplayName = "2# Deve criar instância e converter em string um Person com ToString()")]
        public void DeveRetornarEmStringPerson()
        {
            var personValid = CreatePerson();

            Assert.Contains($"\"Name\":\"{personValid.Name}\"", personValid.ToString());
        }

        [Fact(DisplayName = "3# Deve criar instância e converter em string um Person com Implicit")]
        public void DeveCriarInstanciaConverterStringUmPersonImplicit()
        {
            var personValid = CreatePerson();
            
            Assert.Contains($"\"Name\":\"{personValid.Name}\"", (string)personValid);
        }

        [Fact(DisplayName = "4# Deve criar instância de Person com string modo Implicit")]
        public void DeveRetornarPersonEmString()
        {
            var personEntitieValid = CreatePerson();

            var personString = personEntitieValid.ToString();

            Person personOperatorEntitie = personString;

            Assert.Contains($"\"Name\":\"{personEntitieValid.Name}\"", personString);
            Assert.Contains($"\"Email\":\"{personEntitieValid.Email.Adress}\"", personString);
            Assert.Contains($"\"Type\":\"{personEntitieValid.Type.Type}\"", personString);


            Assert.Contains($"\"Name\":\"{personOperatorEntitie.Name}\"", personString);
            Assert.Contains($"\"Email\":\"{personOperatorEntitie.Email.Adress}\"", personString);
            Assert.Contains($"\"Type\":\"{personOperatorEntitie.Type.Type}\"", personString);
        }

        [Fact(DisplayName = "5# Deve criar instância de Person com um PersonDto modo Implicit")]
        public void DeveCriarInstaciaDePersonComPersonDto()
        {
            var personDtoValid = CreatePersonDto();
            Person personEntitie = personDtoValid;

            Assert.True(personDtoValid != null);
            Assert.True(personEntitie != null);
            Assert.Equal(personEntitie.Name, personDtoValid.Name);
        }


        private Person CreatePerson()
        {
            return new Person("Carlos Junior",
                            new Core.ValueObjects.Email("calos.junior@meudominio.com"),
                            new Core.ValueObjects.PersonType("J"));
        }

        private PersonDto CreatePersonDto()
        {
            return new PersonDto { Name = "Carlos Junior", Email = "calos.junior@meudominio.com", Type = "J" };
        }
    }
}