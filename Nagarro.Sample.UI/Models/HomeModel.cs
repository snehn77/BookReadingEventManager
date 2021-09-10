using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.Sample.UI.Models
{
    public class HomeModel
    {
        public List<BookReadingEvent> FutureEvents = new List<BookReadingEvent>();
        public List<BookReadingEvent> PastEvents = new List<BookReadingEvent>();
    }
}