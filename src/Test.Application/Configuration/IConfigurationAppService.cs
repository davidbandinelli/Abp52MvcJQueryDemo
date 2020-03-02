using System.Threading.Tasks;
using Abp.Application.Services;
using Test.Configuration.Dto;

namespace Test.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}