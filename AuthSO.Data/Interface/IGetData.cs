using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSO.Data.Interface
{
    public interface IGetData
    {
        bool Authenticate(string Username, string Password);
    }
}
