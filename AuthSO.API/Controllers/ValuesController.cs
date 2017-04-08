using AuthSO.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthSO.API.Controllers
{
    public class ValuesController : ApiController
    {
        private IAuthenticator _authService = null;
        //public IAuthenticator AuthService
        //{
        //    get { return (IAuthenticator)(_authService ?? GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthenticator))); }
        //    set { _authService = value; }
        //}
        public ValuesController(IAuthenticator _au)
        {
            this._authService = _au;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IHttpActionResult GetAuth(string Username, string Password)
        {
            return Ok(_authService.Authenticate(Username, Password));
        }
    }
}
