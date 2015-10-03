using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SaveNote.Models.ViewModels
{
    public class NotesView
    {
        [Required(ErrorMessage = "Введите название заметки")]
        public string Name { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public int UserId { get; set; }

        public DateTime AddedDate { get; set; }
    }
}