using Nagarro.Sample.BusinessFacades;
using Nagarro.Sample.EntityDataModel;
using Nagarro.Sample.Shared;
using Nagarro.Sample.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.Sample.UI.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        
        public ActionResult Index()
        {
            Repository repository = new Repository();
            List<BookReadingEvent> eventListDTO = repository.GetAllEvents();
            HomeModel homePageModel = new HomeModel();
            if (Session["userID"] == null)
            {
                foreach (var evt in eventListDTO)
                {
                    if (evt.Type == EventType.Public)
                    {
                        if (evt.Date < DateTime.Now)
                        {
                            homePageModel.PastEvents.Add(evt);
                        }
                        else
                        {
                            homePageModel.FutureEvents.Add(evt);
                        }
                    }
                }
            }
            else
            {
                foreach (var evt in eventListDTO)
                {

                    if (evt.Date < DateTime.Now)
                    {
                        homePageModel.PastEvents.Add(evt);
                    }
                    else
                    {
                        homePageModel.FutureEvents.Add(evt);
                    }

                }
            }

            return View(homePageModel);
        }

        public ActionResult CreateNewEvent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewEvent([Bind(Include = "BookTitle, Date, Location,StartTime,Type,Duration,Description,OtherDetails,InvitedEmails")]CreateEventModel createEvent)
        {
            if (ModelState.IsValid)
            {
                IEventFacade sampleFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
                EventDTO eventDTO = new EventDTO
                {
                    UserID = int.Parse(Session["userID"].ToString()),
                    BookTitle = createEvent.BookTitle,
                    Date = (DateTime)createEvent.Date,
                    Location = createEvent.Location,
                    StartTime = createEvent.StartTime,
                    Type = createEvent.Type,
                    Duration = createEvent.Duration,
                    Description = createEvent.Description,
                    OtherDetails = createEvent.OtherDetails,
                    InvitedEmails = createEvent.InvitedEmails                    
                };
                OperationResult<EventDTO> result = sampleFacade.CreateNewBookEvents(eventDTO);
                if (result.IsValid())
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult GetBookReadingEventDetails(int id)
        {
            IEventFacade sampleFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<EventDTO> result = sampleFacade.GetBookReadingEventDetails(id);
            if (result.IsValid())
            {
                EventDTO eventDTO = result.Data;
                EventDetailModel eventDetailModel = new EventDetailModel();
                EntityConverter.FillEntityFromDTO(eventDTO, eventDetailModel);
                return View("GetBookReadingEventDetails", eventDetailModel);
            }
            return View();
        }
        
        [Authorize]
        public ActionResult GetMyEvents()
        {
            try
            {
                int userID = int.Parse(Session["userID"].ToString());
                Repository repository = new Repository();
                List<BookReadingEvent> result = repository.GetMyEvents(userID);
                List<EventViewModel> myList = new List<EventViewModel>();
                foreach (var i in result)
                {
                    EventViewModel model = new EventViewModel();
                    model.Date = i.Date;
                    model.ID = i.ID;
                    model.Location = i.Location;
                    model.StartTime = i.StartTime;
                    model.BookTitle = i.BookTitle;
                    myList.Add(model);
                }
                myList.Reverse();
                return View("GetMyEvents", myList);
            }
            catch (FormatException)
            {

                return Content("<h1>Input string is not a sequence of digits.<h1>");
            }


        }

        [Authorize]
        public ActionResult EditBookReadingEvent(int id)
        {
            IEventFacade sampleFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<EventDTO> result = sampleFacade.GetBookReadingEventDetails(id);
            if (result.IsValid())
            {
                EventDTO bookReadingEventDTO = result.Data;
                EditEventModel eventModel = new EditEventModel();
                EntityConverter.FillEntityFromDTO(bookReadingEventDTO, eventModel);
                return View(eventModel);
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookReadingEvent([Bind(Include = "ID,BookTitle, Date, Location,StartTime,Type,Duration,Description,OtherDetails,InvitedEmails,CreatedOn,UserID")]EditEventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                EventDTO eventDTO = new EventDTO();
                EntityConverter.FillDTOFromEntity(eventModel,eventDTO);
                //   bookReadingEventDTO.UserID = int.Parse(Session["userID"].ToString());
                IEventFacade sampleFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
                OperationResult<EventDTO> result = sampleFacade.EditBookReadingEvent(eventDTO);
                if (result.IsValid())
                {
                    if (Session["emailID"].ToString() == "sneh@admin.com")
                    {
                        return RedirectToAction("AdminHome");
                    }
                    return RedirectToAction("GetMyEvents");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult GetInvitedEvents()
        {
            string email = Session["emailID"].ToString();
            Repository repository = new Repository();
            List<BookReadingEvent> result = repository.InvitedEvents(email);
            List<EventViewModel> myList = new List<EventViewModel>();
            foreach (var i in result)
            {
                EventViewModel model = new EventViewModel();
                model.Date = i.Date;
                model.ID = i.ID;
                model.Location = i.Location;
                model.StartTime = i.StartTime;
                model.BookTitle = i.BookTitle;
                myList.Add(model);
            }
            return View(myList);
        }

        [Authorize]
        public ActionResult AdminHome()
        {
            Repository repository = new Repository();
            List<BookReadingEvent> eventListDTO = repository.GetAllEvents();
            List<EventViewModel> adminHomeModel = new List<EventViewModel>();
            foreach (var i in eventListDTO)
            {
                EventViewModel model = new EventViewModel();
                model.Date = i.Date;
                model.ID = i.ID;
                model.Location = i.Location;
                model.StartTime = i.StartTime;
                model.BookTitle = i.BookTitle;
                adminHomeModel.Add(model);
            }
            return View(adminHomeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment([Bind(Include = "ID,Comments")]EventDetailModel eventDetailModel)
        {
                if (ModelState.IsValid)
                {

                    PostedCommentDTO postedCommentDTO = new PostedCommentDTO();
                    postedCommentDTO.BookReadingEventID = eventDetailModel.ID;
                    postedCommentDTO.Comments = eventDetailModel.Comments;
                    postedCommentDTO.EmailID = Session["emailID"].ToString();
                    IPostedCommentsFacade sampleFacade = (IPostedCommentsFacade)FacadeFactory.Instance.Create(FacadeType.PostedCommentsFacade);
                    OperationResult<PostedCommentDTO> result = sampleFacade.PostComment(postedCommentDTO);
                    return RedirectToAction("GetBookReadingEventDetails", new { id = eventDetailModel.ID });
                }
            return View();
        }

        [ChildActionOnly]
        public ActionResult Comments(int eventID)
        {
            Repository repository = new Repository();
            List<PostedComment> postedCommentDTO = repository.GetComments(eventID);
            List<PostedCommentModel> commentsModel = new List<PostedCommentModel>();

            foreach (var i in postedCommentDTO)
            {
                PostedCommentModel model = new PostedCommentModel();
                model.BookReadingEventID = i.BookReadingEventID;
                model.Comments = i.Comments;
                model.CreatedOn = i.CreatedOn;
                model.EmailID = i.EmailID;
                commentsModel.Add(model);
            }
            return PartialView(commentsModel);

        }
    }
}