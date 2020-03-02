using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.UI;
using Test.Authorization;
using Test.Authorization.Roles;
using Test.Authorization.Users;
using CTC.Entities;
using CTC.Phonebook.Dto;
using CTC.Phonebook.Interfaces;
//using CTC.Roles.Dto;
using Microsoft.AspNet.Identity;

namespace CTC.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Phonebook)]
    public class PersonAppService : AsyncCrudAppService<Person, PersonListDto, int, PagedResultRequestDto, PersonListDto, PersonListDto>, IPersonAppService {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(
            IRepository<Person> personRepository)
            : base(personRepository)
        {
            _personRepository = personRepository;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input) {
            var persons = _personRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                            p.Surname.Contains(input.Filter) ||
                            p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(persons));
        }

        public async Task CreatePerson(CreatePersonInput input) {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

        [AbpAuthorize(PermissionNames.Pages_Phonebook_DeletePerson)]
        public async Task DeletePerson(EntityDto input) {
            await _personRepository.DeleteAsync(input.Id);
        }

        public PersonDto GetPersonForEdit(EntityDto<int> input)
        {
            var person = _personRepository.Get(input.Id);
            var personToReturn = ObjectMapper.Map<PersonDto>(person);
            return personToReturn;
        }

        public async Task<PersonDto> UpdatePerson(PersonDto input)
        {
            var person = await _personRepository.GetAsync(input.Id);

            MapToEntity(input, person);

            await _personRepository.UpdateAsync(person);

            return GetPersonForEdit(input);
        }

        private void MapToEntity(PersonDto input, Person person)
        {
            ObjectMapper.Map(input, person);
        }
    }
}