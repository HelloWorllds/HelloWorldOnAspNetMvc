using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public partial class SqlRepository
    {
        public IQueryable<YouTubeLinks> YouTubeLink
        {
            get
            {
                return Db.YouTubeLinks;
            }
        }

        public bool CreateYouTubeLink(YouTubeLinks instance)
        {
            if (instance.ID == 0)
            {
                Db.YouTubeLinks.InsertOnSubmit(instance);
                Db.YouTubeLinks.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateYouTubeLink(YouTubeLinks instance)
        {
            YouTubeLinks cache = Db.YouTubeLinks.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Name = instance.Name;
                cache.YTUrl = instance.YTUrl;
                cache.Description = instance.Description;
                Db.YouTubeLinks.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveYouTubeLink(int idYouTubeLink)
        {
            YouTubeLinks instance = Db.YouTubeLinks.FirstOrDefault(p => p.ID == idYouTubeLink);
            if (instance != null)
            {
                Db.YouTubeLinks.DeleteOnSubmit(instance);
                Db.YouTubeLinks.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
