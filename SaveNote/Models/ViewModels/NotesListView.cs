using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveNote.Models.ViewModels
{
    public class NotesListView
    {
        public IEnumerable<string> SelectedNote { get; set; }
        public IEnumerable<SelectListItem> Notes { get; set; }
    }
}