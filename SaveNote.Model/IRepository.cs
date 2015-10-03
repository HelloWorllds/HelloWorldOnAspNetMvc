using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveNote.Model
{
    public interface IRepository
    {
        #region Role
        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion


        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        bool RemoveUser(int idUser);

        User GetUser(string email);

        User Login(string email, string password);

        #endregion


        #region UserRole

        IQueryable<UserRole> UserRoles { get; }

        bool CreateUserRole(UserRole instance);

        bool UpdateUserRole(UserRole instance);

        bool RemoveUserRole(int idUserRole);

        #endregion

        #region Bookmarks

        IQueryable<Bookmarks> Bookmark { get; }

        bool CreateBookmark(Bookmarks instance);

        bool UpdateBookmark(Bookmarks instance);

        bool RemoveBookmark(int idBookmark);

        #endregion

        #region Notes

        IQueryable<Notes> Note { get; }

        bool CreateNote(Notes instance);

        bool UpdateNote(Notes instance);

        bool RemoveNote(int idNote);

        #endregion

        #region Passwords

        IQueryable<Passwords> Password { get; }

        bool CreatePassword(Passwords instance);

        bool UpdatePassword(Passwords instance);

        bool RemovePassword(int idPassword);

        #endregion

        #region YouTubeLinks

        IQueryable<YouTubeLinks> YouTubeLink { get; }

        bool CreateYouTubeLink(YouTubeLinks instance);

        bool UpdateYouTubeLink(YouTubeLinks instance);

        bool RemoveYouTubeLink(int idYouTubeLink);

        #endregion

        #region Calendar

        IQueryable<Calendar> Calendar { get; }

        bool CreateCalendar(Calendar instance);

        bool RemoveCalendar(int idCalendar);

        #endregion
    }
}
