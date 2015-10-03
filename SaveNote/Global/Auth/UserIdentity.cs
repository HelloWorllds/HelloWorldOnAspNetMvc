using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaveNote.Model;
using System.Security.Principal;

namespace SaveNote.Global.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get { return typeof(User).ToString(); }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }

                return "Аноним";
            }
        }

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }
    }
}