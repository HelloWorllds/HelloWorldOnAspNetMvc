using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SaveNote.Models.ViewModels
{
    public class CalendarView
    {
        public string Description { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public IEnumerable<SelectListItem> HoursList
        {
            get
            {
                for (int i = 0; i < 24; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = (i < 10) ? "0" + i.ToString() : i.ToString(),
                        Selected = Hours == i
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> MinutesList
        {
            get
            {
                for (int i = 0; i < 60; i++)
                {
                    if (i % 10 == 0)
                    {
                        yield return new SelectListItem
                        {
                            Value = i.ToString(),
                            Text = (i < 10) ? "0" + i.ToString() : i.ToString(),
                            Selected = Minutes == i
                        };
                    }
                }
            }
        }

        public IEnumerable<SelectListItem> DaySelectList
        {
            get
            {
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = Day == i
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> MonthSelectList
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(2000, i, 1).ToString("MMMM"),
                        Selected = Month == i
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> YearSelectList
        {
            get
            {
                for (int i = 2015; i < DateTime.Now.Year + 1; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = Year == i
                    };
                }
            }
        }
    }
}