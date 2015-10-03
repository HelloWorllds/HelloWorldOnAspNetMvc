using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SaveNote.Model;
using System.Security.Principal;

namespace SaveNote.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool isPersistent);

        void Logout();

        IPrincipal CurrentUser { get; }
    }
}
