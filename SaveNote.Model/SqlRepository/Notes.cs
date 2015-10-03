using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public partial class SqlRepository
    {
        public IQueryable<Notes> Note
        {
            get
            {
                return Db.Notes;
            }
        }

        public bool CreateNote(Notes instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
                Db.Notes.InsertOnSubmit(instance);
                Db.Notes.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateNote(Notes instance)
        {
            Notes cache = Db.Notes.FirstOrDefault(p => p.Name == instance.Name);
            cache.Content = instance.Content;
            Db.Notes.Context.SubmitChanges();
            return true;
        }

        public bool RemoveNote(int idNote)
        {
            Notes instance = Db.Notes.FirstOrDefault(p => p.ID == idNote);
            if (instance != null)
            {
                Db.Notes.DeleteOnSubmit(instance);
                Db.Notes.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
