using Nagarro.Sample.Business;
using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.BusinessFacades
{
    public class EventFacade :FacadeBase, IEventFacade
    {
        public EventFacade()
           : base(FacadeType.EventFacade)
        {

        }

        public OperationResult<EventDTO> CreateNewBookEvents(EventDTO eventDTO)
        {
            IEventBDC sampleBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return sampleBDC.CreateNewBookEvents(eventDTO);
        }

        public OperationResult<EventDTO> GetBookReadingEventDetails(int id)
        {
            IEventBDC sampleBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return sampleBDC.GetBookReadingEventDetails(id);
        }

        public OperationResult<EventDTO> EditBookReadingEvent(EventDTO eventDTO)
        {
            IEventBDC sampleBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return sampleBDC.EditBookReadingEvent(eventDTO);
        }
    }
}
