using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public partial class SqlRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                return Db.User;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.ID == 0)
            {
                instance.Password = User.CreatePassHash(instance.Password);
                instance.AddedDate = DateTime.Now;
                instance.ActivatedLink = User.GetActivateUrl();
                Db.User.InsertOnSubmit(instance);
                Db.User.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = Db.User.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                cache.Birthdate = instance.Birthdate;
                cache.AvatarPath = instance.AvatarPath;
                cache.Email = instance.Email;
                Db.User.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUser(int idUser)
        {
            User instance = Db.User.Where(p => p.ID == idUser).FirstOrDefault();
            if (instance != null)
            {
                Db.User.DeleteOnSubmit(instance);
                Db.User.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return Db.User.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            string passHash = User.CreatePassHash(password);

            return Db.User.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == passHash);
        }
    }
}
