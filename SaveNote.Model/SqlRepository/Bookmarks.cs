using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public partial class SqlRepository
    {
        public IQueryable<Bookmarks> Bookmark
        {
            get
            {
                return Db.Bookmarks;
            }
        }

        public bool CreateBookmark(Bookmarks instance)
        {
            if (instance.ID == 0)
            {
                Db.Bookmarks.InsertOnSubmit(instance);
                Db.Bookmarks.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateBookmark(Bookmarks instance)
        {
            Bookmarks cache = Db.Bookmarks.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Name = instance.Name;
                cache.Url = instance.Url;
                Db.Bookmarks.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveBookmark(int idBookmark)
        {
            Bookmarks instance = Db.Bookmarks.FirstOrDefault(p => p.ID == idBookmark);
            if (instance != null)
            {
                Db.Bookmarks.DeleteOnSubmit(instance);
                Db.Bookmarks.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
