using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveNote.Models.Info
{
    public class CalendarModel
    {
    }

    public class WeekForMonth
    {
        public List<Day> Week1 { get; set; }
        public List<Day> Week2 { get; set; }
        public List<Day> Week3 { get; set; }
        public List<Day> Week4 { get; set; }
        public List<Day> Week5 { get; set; }
        public List<Day> Week6 { get; set; }
        public string nextMonth { get; set; }
        public string prevMonth { get; set; }
    }

    public class Day
    {
        public DateTime Date { get; set; }
        public string _Date { get; set; }
        public string dateStr { get; set; }
        public int dtDay { get; set; }
        public int? daycolumn { get; set; }

    }

    public class PopulateMonth
    {
        public int month { get; set; }
        public int totaldayformonth { get; set; }
        public int year { get; set; }
    }
}