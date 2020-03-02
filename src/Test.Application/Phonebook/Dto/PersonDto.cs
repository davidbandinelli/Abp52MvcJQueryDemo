using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CTC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Enums;

namespace CTC.Phonebook.Dto {


    public class GetPeopleInput {
        public string Filter { get; set; }
    }

    public class PersonListDto : FullAuditedEntityDto {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
        public string TelephoneNumber  { get; set; }
        public TipiContatto TipoContatto { get; set; }
    }

    public class CreatePersonInput {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }
        public TipiContatto TipoContatto { get; set; }
    }

    [AutoMapFrom(typeof(Person))]
    public class PersonDto : EntityDto<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }
        public TipiContatto TipoContatto { get; set; }
    }

}
