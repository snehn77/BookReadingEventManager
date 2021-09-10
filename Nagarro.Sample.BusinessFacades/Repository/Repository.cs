using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.BusinessFacades
{
    public class Repository
    {
        public List<BookReadingEvent> GetAllEvents()
        {
            List<BookReadingEvent> retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    List<BookReadingEvent> result = dbContext.BookReadingEvents.ToList();
                    retVal = result;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<BookReadingEvent> GetMyEvents(int userID)
        {
            List<BookReadingEvent> retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    List<BookReadingEvent> result = dbContext.BookReadingEvents.Where(x => x.UserID == userID).ToList();
                    retVal = result;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<BookReadingEvent> InvitedEvents(string email)
        {
            List<BookReadingEvent> eventList = new List<BookReadingEvent>();
            List<object> tempList = GetInvitedEvents(email);
            foreach (object eventDTO in tempList)
            {
                eventList.Add((BookReadingEvent)eventDTO);
            }
            return eventList;
        }

        public List<object> GetInvitedEvents(string email)
        {
            using (EventDbContext dbContext = new EventDbContext())
            {
                var eventList = dbContext.BookReadingEvents.ToList();
                List<object> invitedEventList = new List<object>();
                foreach (var evt in eventList)
                {
                    if (evt.InvitedEmails != null)
                    {
                        if (evt.InvitedEmails.Split(',').ToList().Find(ema => ema == email) != null)
                        {
                            invitedEventList.Add(evt);
                        }
                    }
                }
                return invitedEventList;
            }
        }

        public List<PostedComment> GetComments(int eventID)
        {
            using (EventDbContext dbContext = new EventDbContext())
            {
                List<PostedComment> postedComments = dbContext.PostedComments.Where(comment => comment.BookReadingEventID == eventID).ToList();
                return postedComments;
            }
        }
    }
}
