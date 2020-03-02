using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Test.MultiTenancy.Dto;

namespace Test.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
