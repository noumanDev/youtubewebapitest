using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using youtubeapiweb.Models;

namespace youtubeapiweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //MyUploads.Main(null);
            return Content("hello");
        }

        public ActionResult About()
        {
            return Redirect(@"https://accounts.google.com/o/oauth2/v2/auth?scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.readonly&access_type=offline&include_granted_scopes=true&state=state_parameter_passthrough_value&redirect_uri=http://localhost:37783/home/contact&response_type=code&client_id=915455549090-ejrlgupml7jsinskhtpq7sjpbr309iau.apps.googleusercontent.com");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}