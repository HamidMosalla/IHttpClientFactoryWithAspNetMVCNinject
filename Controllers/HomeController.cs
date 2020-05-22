using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IHttpFactoryWithAspNetMVCNinject.Services;

namespace IHttpFactoryWithAspNetMVCNinject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlStringReader _urlStringReader;

        public HomeController(IUrlStringReader urlStringReader)
        {
            _urlStringReader = urlStringReader;
        }

        public async Task<ActionResult> Index()
        {
            var str = await _urlStringReader.GetJsonAsyncCorrectUsage(new Uri("https://google.com"));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}