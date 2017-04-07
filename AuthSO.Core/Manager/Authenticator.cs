using AuthSO.Core.Interface;
using AuthSO.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSO.Core.Manager
{
    public class Authenticator : IAuthenticator,IDisposable
    {
        public IGetData _get;
        public Authenticator(IGetData _get)
        {
            this._get = _get;
        }
        public bool Authenticate(string Username, string Password)
        {
            return _get.Authenticate(Username, Password);
        }

        public void Dispose()
        {
        }
    }
}
