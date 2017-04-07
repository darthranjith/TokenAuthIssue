using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSO.Core.Interface
{
    public interface IAuthenticator
    {
        bool Authenticate(string Username, string Password);
    }
}
