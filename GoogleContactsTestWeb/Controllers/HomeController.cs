using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace GoogleContactsTestWeb.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(Views.Index);
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View(Views.About);
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(Views.Contact);
        }

        [HttpGet]
        public virtual ActionResult GoogleAuth()
        {
            const string oauthGoogleUrl = "https://accounts.google.com/o/oauth2/auth?scope={0}&redirect_uri={1}&response_type=code&client_id={2}&access_type=online&approval_prompt=force";
            const string googleApiScope = "https://www.google.com/m8/feeds";
            const string oauthRedirectUrl = "http://localhost:64901/GoogleAuthCallback";
            const string googleClientId = "1051352266030-l2avpmbf9kk0s8b9eshqu6fkd0gee50g.apps.googleusercontent.com";
            
            var authGoogleUrl = String.Format(
                oauthGoogleUrl,
                Uri.EscapeDataString(googleApiScope),
                Uri.EscapeDataString(oauthRedirectUrl),
                googleClientId);

            return Redirect(authGoogleUrl);
        }

        [HttpGet]
        public virtual ActionResult GoogleAuthCallback(string code = null, string error = null)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                return View(Views.Index);
            }

            var client = new WebClient();

            var parameters = new NameValueCollection
            {
                { "client_id", "1051352266030-l2avpmbf9kk0s8b9eshqu6fkd0gee50g.apps.googleusercontent.com" },
                { "client_secret", "5Ai2kKsRUK8Av5RehYB3rx7k" },
                { "grant_type", "authorization_code" },
                { "redirect_uri", "http://localhost:64901/GoogleAuthCallback" },
                { "code", code }
            };

            var rawResponse = client.UploadValues("https://accounts.google.com/o/oauth2/token", parameters);
            var responseString = Encoding.UTF8.GetString(rawResponse);
            dynamic tokenData = JsonConvert.DeserializeObject(responseString);

            rawResponse = client.DownloadData(String.Format("https://www.google.com/m8/feeds/contacts/default/full?access_token={0}&alt=json", tokenData.access_token));
            responseString = Encoding.UTF8.GetString(rawResponse);

            dynamic contactsData = JsonConvert.DeserializeObject(responseString);

            return View(Views.Index);
        }
    }
}
