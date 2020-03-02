using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using CTC.Phonebook.Dto;
using CTC.Phonebook.Interfaces;
using Test.Users;
using Test.Users.Dto;
using Shouldly;
using Xunit;
using Test.Tests;

namespace CTC.Tests.Phonebook
{
    public class PersonAppService_Tests : TestTestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests() {
            _personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public void Should_Get_All_People_Without_Any_Filter() {
            //Act
            var persons = _personAppService.GetPeople(new GetPeopleInput());

            //Assert
            persons.Items.Count.ShouldBe(1);
        }

        [Fact]
        public void Should_Get_People_With_Filter() {
            //Act
            var persons = _personAppService.GetPeople(
                new GetPeopleInput {
                    Filter = "bandinelli"
                });

            //Assert
            persons.Items.Count.ShouldBe(1);
            persons.Items[0].Name.ShouldBe("David");
            persons.Items[0].Surname.ShouldBe("Bandinelli");
        }


        [Fact]
        public async Task Should_Create_Person_With_Valid_Arguments() {
            //Act
            await _personAppService.CreatePerson(
                new CreatePersonInput {
                    Name = "John",
                    Surname = "Nash",
                    EmailAddress = "john.nash@abeautifulmind.com"
                });

            //Assert
            UsingDbContext(
                context => {
                    var john = context.Persons.FirstOrDefault(p => p.EmailAddress == "john.nash@abeautifulmind.com");
                    john.ShouldNotBe(null);
                    john.Name.ShouldBe("John");
                });
        }

        [Fact]
        public async Task Should_Not_Create_Person_With_Invalid_Arguments() {
            //Act and Assert
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _personAppService.CreatePerson(
                    new CreatePersonInput {
                        Name = "John"
                    });
                });
        }

    }
}
