using AuthSO.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSO.Data.Repository
{
    public class GetData : IGetData
    {
        public bool Authenticate(string Username, string Password)
        {
            if (Username == "admin" && Password == "admin")
                return true;
            else
                return false;
        }
    }
}
