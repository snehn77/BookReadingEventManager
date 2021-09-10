using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    public interface IEventDAC : IDataAccessComponent
    {
        EventDTO CreateNewBookEvents(EventDTO eventDTO);
        EventDTO GetBookReadingEventDetails(int id);
        EventDTO EditBookReadingEvent(EventDTO eventDTO);
    }
}
