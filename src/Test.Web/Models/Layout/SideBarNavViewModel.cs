using Abp.Application.Navigation;

namespace Test.Web.Models.Layout
{
    public class SideBarNavViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}