using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.Sample.UI.Models
{
    public class EventDetailModel
    {
        public int ID { get; set; }

        public string BookTitle { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string StartTime { get; set; }

        public EventType Type { get; set; }

        public int? Duration { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InvitedEmails { get; set; }

        public string Comments { get; set; }

        public int UserID { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}