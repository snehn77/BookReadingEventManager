using Nagarro.Sample.Data;
using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using Nagarro.Sample.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Sample.Business
{
    public class EventBDC : BDCBase, IEventBDC
    {
        private readonly IDACFactory dacFacotry;

        /// <summary>
        /// 
        /// </summary>
        public EventBDC()
            : base(BDCType.EventBDC)
        {
            dacFacotry = DACFactory.Instance;
        }

        public EventBDC(IDACFactory dacFacotry)
            : base(BDCType.EventBDC)
        {
            this.dacFacotry = dacFacotry;
        }

        public OperationResult<EventDTO> CreateNewBookEvents(EventDTO eventDTO)
        {
            OperationResult<EventDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<EventValidator, EventDTO>.Validate(eventDTO);
                if (validationResult.IsValid)
                {
                    IEventDAC sampleDAC = (IEventDAC)dacFacotry.Create(DACType.EventDAC);
                    EventDTO resultDTO = sampleDAC.CreateNewBookEvents(eventDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<EventDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<EventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<EventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<EventDTO> GetBookReadingEventDetails(int id)
        {
            OperationResult<EventDTO> retVal = null;
            IEventDAC sampleDAC = (IEventDAC)dacFacotry.Create(DACType.EventDAC);
            EventDTO resultDTO = sampleDAC.GetBookReadingEventDetails(id);
            if (resultDTO != null)
            {
                retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
            }
            else
            {
                retVal = OperationResult<EventDTO>.CreateFailureResult("Failed!");
            }
            return retVal;
        }

        public OperationResult<EventDTO> EditBookReadingEvent(EventDTO eventDTO)
        {
            OperationResult<EventDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<EventValidator, EventDTO>.Validate(eventDTO);
                if (validationResult.IsValid)
                {
                    IEventDAC sampleDAC = (IEventDAC)dacFacotry.Create(DACType.EventDAC);
                    EventDTO resultDTO = sampleDAC.EditBookReadingEvent(eventDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<EventDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<EventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<EventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

    }
}
