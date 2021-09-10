using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.Sample.UI.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string StartTime { get; set; }
    }
}