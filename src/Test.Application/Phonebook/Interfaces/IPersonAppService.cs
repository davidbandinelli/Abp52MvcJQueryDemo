using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CTC.Phonebook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC.Phonebook.Interfaces {
    public interface IPersonAppService : IApplicationService {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);
        Task DeletePerson(EntityDto input);
        PersonDto GetPersonForEdit(EntityDto<int> input);
        Task<PersonDto> UpdatePerson(PersonDto input);

    }

}
