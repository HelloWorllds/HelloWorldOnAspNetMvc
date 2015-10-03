using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SaveNote.Model;
using System.Web.Security;
using System.Security.Principal;

namespace SaveNote.Global.Auth
{
    public class CustomAuthentication : IAuthentication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private const string cookieName = "__AUTH_COOKIE";

        public HttpContext HttpContext { get; set; }

        [Inject]
        public IRepository Repository { get; set; }

        #region IAuthentication

        public User Login(string login, string password, bool isPersistent)
        {
            User user = Repository.Login(login, password);

            if (user != null)
            {
                CreateCookie(login, isPersistent);
            }

            return user;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                    1,
                    userName,
                    DateTime.Now,
                    DateTime.Now.Add(FormsAuthentication.Timeout),
                    isPersistent,
                    string.Empty,
                    FormsAuthentication.FormsCookiePath
                );

            var encTicket = FormsAuthentication.Encrypt(ticket);

            var AuthCookie = new HttpCookie(cookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };

            HttpContext.Response.Cookies.Set(AuthCookie);
        }

        public void Logout()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];

            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);

                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name, Repository);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentication: " + ex.Message);
                        _currentUser = new UserProvider(null, null);
                    }
                }

                return _currentUser;
            }
        }

        #endregion
    }
}