using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SaveNote.Model;
using SaveNote.Models.ViewModels;

namespace SaveNote.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<User, UserView>()
                    .ForMember(dest => dest.BirthdateDay, opt => opt.MapFrom(src => src.Birthdate.Day))
                    .ForMember(dest => dest.BirthdateMonth, opt => opt.MapFrom(src => src.Birthdate.Month))
                    .ForMember(dest => dest.BirthdateYear, opt => opt.MapFrom(src => src.Birthdate.Year));
            Mapper.CreateMap<UserView, User>()
                    .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => new DateTime(src.BirthdateYear, src.BirthdateMonth, src.BirthdateDay)));


            Mapper.CreateMap<Notes, NotesView>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID));

            Mapper.CreateMap<NotesView, Notes>()
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));


            Mapper.CreateMap<Bookmarks, BookmarkView>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID));

            Mapper.CreateMap<BookmarkView, Bookmarks>()
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));


            Mapper.CreateMap<Passwords, PasswordsView>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID));

            Mapper.CreateMap<PasswordsView, Passwords>()
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));


            Mapper.CreateMap<YouTubeLinks, VideoView>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID));

            Mapper.CreateMap<VideoView, YouTubeLinks>()
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));

            Mapper.CreateMap<Calendar, CalendarView>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID));

            Mapper.CreateMap<CalendarView, Calendar>()
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}