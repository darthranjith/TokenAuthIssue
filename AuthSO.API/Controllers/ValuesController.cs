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
        private IAuthenticator _au = null;
        public ValuesController(IAuthenticator _au)
        {
            this._au = _au;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        public IHttpActionResult GetAuth(string Username, string Password)
        {
            return Ok(_au.Authenticate(Username, Password));
        }
    }
}
