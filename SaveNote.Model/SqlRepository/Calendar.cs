using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public partial class SqlRepository
    {
        public IQueryable<Calendar> Calendar
        {
            get
            {
                return Db.Calendar;
            }
        }

        public bool CreateCalendar(Calendar instance)
        {
            if (instance.ID == 0)
            {
                Db.Calendar.InsertOnSubmit(instance);
                Db.Calendar.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveCalendar(int idCalendar)
        {
            Calendar instance = Db.Calendar.FirstOrDefault(p => p.ID == idCalendar);
            if (instance != null)
            {
                Db.Calendar.DeleteOnSubmit(instance);
                Db.Calendar.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
