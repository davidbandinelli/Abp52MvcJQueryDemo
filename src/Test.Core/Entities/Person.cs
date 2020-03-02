using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using Test.Entities.Enums;

namespace CTC.Entities
{
    public class PersonConsts {
        public const int MaxNameLength = 32;
        public const int MaxSurnameLength = 32;
        public const int MaxEmailAddressLength = 255;
    }

    [Table("PbPersons")]
    public class Person : FullAuditedEntity {
        [Required]
        [MaxLength(PersonConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(PersonConsts.MaxSurnameLength)]
        public virtual string Surname { get; set; }

        [MaxLength(PersonConsts.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }

        public TipiContatto TipoContatto { get; set; }
    }
}