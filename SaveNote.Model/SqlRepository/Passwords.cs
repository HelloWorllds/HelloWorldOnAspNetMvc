using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public partial class SqlRepository
    {
        public IQueryable<Passwords> Password
        {
            get
            {
                return Db.Passwords;
            }
        }

        public bool CreatePassword(Passwords instance)
        {
            if (instance.ID == 0)
            {
                Db.Passwords.InsertOnSubmit(instance);
                Db.Passwords.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdatePassword(Passwords instance)
        {
            Passwords cache = Db.Passwords.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Login = instance.Login;
                cache.Password = instance.Password;
                cache.Resource = instance.Resource;
                Db.Passwords.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemovePassword(int idPassword)
        {
            Passwords instance = Db.Passwords.FirstOrDefault(p => p.ID == idPassword);
            if (instance != null)
            {
                Db.Passwords.DeleteOnSubmit(instance);
                Db.Passwords.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
