using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Test.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}