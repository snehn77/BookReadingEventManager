using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Shared
{
    public interface IEventBDC : IBusinessDomainComponent
    {
        OperationResult<EventDTO> CreateNewBookEvents(EventDTO eventDTO);
        OperationResult<EventDTO> GetBookReadingEventDetails(int id);
        OperationResult<EventDTO> EditBookReadingEvent(EventDTO eventDTO);
    }
}
