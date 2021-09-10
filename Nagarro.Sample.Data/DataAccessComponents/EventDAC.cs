using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Data
{
    public class EventDAC : DACBase, IEventDAC
    {
        public EventDAC()
           : base(DACType.EventDAC)
        {

        }

        public EventDTO CreateNewBookEvents(EventDTO eventDTO)
        {
            EventDTO retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    eventDTO.CreatedOn = DateTime.Now;
                    BookReadingEvent bookEvent = new BookReadingEvent();
                    EntityConverter.FillEntityFromDTO(eventDTO, bookEvent);
                    bookEvent.ModifiedOn = DateTime.Now;
                    dbContext.BookReadingEvents.Add(bookEvent);
                    dbContext.SaveChanges();
                    retVal = eventDTO;

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public EventDTO EditBookReadingEvent(EventDTO eventDTO)
        {
            EventDTO retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    var editedEvent = dbContext.BookReadingEvents.Where(x => x.ID == eventDTO.ID).FirstOrDefault();
                    if (editedEvent != null)
                    {
                        editedEvent.BookTitle = eventDTO.BookTitle;
                        editedEvent.CreatedOn = eventDTO.CreatedOn;
                        editedEvent.Date = eventDTO.Date;
                        editedEvent.Description = eventDTO.Description;
                        editedEvent.Duration = eventDTO.Duration;
                        editedEvent.InvitedEmails = eventDTO.InvitedEmails;
                        editedEvent.Location = eventDTO.Location;
                        editedEvent.OtherDetails = eventDTO.OtherDetails;
                        editedEvent.Type = eventDTO.Type;
                        editedEvent.UserID = eventDTO.UserID;
                        editedEvent.StartTime = eventDTO.StartTime;
                        editedEvent.ModifiedOn = DateTime.Now;
                        dbContext.Entry(editedEvent).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        retVal = eventDTO;
                    } 
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public EventDTO GetBookReadingEventDetails(int id)
        {
            EventDTO retVal = null;
            try
            {
                using (EventDbContext dbContext = new EventDbContext())
                {
                    var bookEvent = dbContext.BookReadingEvents.Find(id);
                    EventDTO eventDTO = new EventDTO();
                    EntityConverter.FillDTOFromEntity(bookEvent,eventDTO);
                    retVal = eventDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

    }
}
