using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VimeoDotNet;
using VimeoDotNet.Authorization;
using VimeoDotNet.Exceptions;
using VimeoDotNet.Models;
using VimeoDotNet.Net;
using VimeoDotNet.Constants;
using System.Net.Http;
using System.Security.Authentication;

namespace youtubeapiweb.Controllers
{
    public class VimeoController : Controller
    {

        string State { get; set; } = "ajlj32jluc90j2lj30";
        string ClientID { get; set; } = "9c60da3925d05e1431767be7c74e7e73740369460";
        string ClientSecret { get; set; } = "84p1DIclDldxMAj7qVnNPPShQIksiHZVxn7Kck8a4MVLEBcZ8ENvIq3HBmndAd3RDlHMnxTDZajCT8HTiW/HG8qfhrAjfCwdWhVZZUpvmOPyxDBdOYg0lGy2Lf8a+NsU0";
        string RedirectUri { get; set; } = "http://localhost:37783/vimeo/authconfirmredirect";
        string AccessTokenRedirectUri { get; set; } = "http://localhost:37783/vimeo/accesstokenredirect";

        List<string> Scope { get; set; } = new List<string>() { "private" };
        public AuthorizationClient Client { get; set; }

        public VimeoController()
        {
            Client = new AuthorizationClient(ClientID, ClientSecret);
            
        }


        // GET: Vimeo
        public ActionResult Auth()
        {

            string redirecUrl = Client.GetAuthorizationEndpoint(RedirectUri, Scope, State);
            return Redirect(redirecUrl);
        }

        public async Task<ActionResult> AuthConfirmRedirect(string code, string state)
        {
            
                if (state != State)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "State varification failed");
                }

                const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                ServicePointManager.SecurityProtocol = Tls12;
                AccessTokenResponse AccessTokenResponse = await Client.GetAccessTokenAsync(code, RedirectUri);

                return Content("authconfirm");
                //in case of exception it will return 400, if authorization code or redirect uri is invalid

            
        }

        public ActionResult AccessTokenRedirect(string code, string state)
        {
            return Content("authconfirm");
        }

    }
}