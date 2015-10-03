using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaveNote.Models.ViewModels
{
    public class VideoView
    {
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите адрес ролика с YouTube")]
        public string YTUrl { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
    }
}