using System.Collections.Generic;
using Test.Roles.Dto;
using Test.Users.Dto;

namespace Test.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}