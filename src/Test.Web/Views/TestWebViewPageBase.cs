using Abp.Web.Mvc.Views;

namespace Test.Web.Views
{
    public abstract class TestWebViewPageBase : TestWebViewPageBase<dynamic>
    {

    }

    public abstract class TestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TestWebViewPageBase()
        {
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}