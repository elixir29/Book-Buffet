using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookBuffet.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventFacade eventBFL;
        public EventController()
        {
            eventBFL = (IEventFacade)BusinessFacadeFactory.Instance.Create(BusinessFacadeType.EventFacade);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EventDTO eventDTO, String str)
        {
            if (ModelState.IsValid)
            {
                eventBFL.AddEvent(eventDTO, HttpContext.User.Identity.Name);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult MyEvent()
        {
            List<EventDTO> myevent = eventBFL.GetAllUserEvent(HttpContext.User.Identity.Name);
            return View(myevent);
        }

        public ActionResult Details(int id)
        {
            var cookie = new HttpCookie("id", id.ToString());
            Response.Cookies.Add(cookie);

            EventDTO @event = eventBFL.GetEvent(id);
            return View(@event);
        }


        public ActionResult Edit(int id)
        {
            EventDTO @event = eventBFL.GetEvent(id);
            return View(@event);
        }

        [HttpPost]
        public ActionResult Edit(int id, EventDTO _event)
        {
            if (ModelState.IsValid)
            {
                eventBFL.UpdateEvent(_event.EventId, _event);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult EventInvite()
        {
            string userid = HttpContext.User.Identity.Name;
            int id = int.Parse(userid);

            List<EventDTO> @event = eventBFL.GetEventInvite(id);
            return View(@event);
        }

        //List of events particular user can edit !!!
        public ActionResult EditIndex()
        {
            List<EventDTO> @futureevent = eventBFL.GetEventByUser(HttpContext.User.Identity.Name);
            return View(futureevent);
        }


        public ActionResult AdminEdit()
        {
            List<EventDTO> @event = eventBFL.GetEventByUser("0");
            return View("EditIndex", @event);
        }

        public ActionResult FutureEvent()
        {

            dynamic dynamic = new ExpandoObject();
            dynamic.FutureEventDTO = eventBFL.GetfutureEvent();
            return View(dynamic);
        }

        public ActionResult PastEvent()
        {
            dynamic dynamic = new ExpandoObject();
            dynamic.PastEventDTO = eventBFL.GetpastEvent();
            return View(dynamic);
        }
    }
}