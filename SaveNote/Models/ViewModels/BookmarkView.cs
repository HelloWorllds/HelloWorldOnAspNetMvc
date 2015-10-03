using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaveNote.Models.ViewModels
{
    public class BookmarkView
    {
        [Required(ErrorMessage = "Введите название закладки")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите адрес закладки")]
        public string Url { get; set; }

        public int LaunchCount { get; set; }

        public int UserId { get; set; }
    }
}