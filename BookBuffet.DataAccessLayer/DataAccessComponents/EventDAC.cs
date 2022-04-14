
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBuffet.Shared;

namespace BookBuffet.DataAccessLayer
{
    public class EventDAC : DACBase, IEventDAC
    {
        public EventDAC()
            : base(DataAccessType.EventDAC)
        {

        }
        public void AddEvent(EventDTO events,string str)
        {
            int id = int.Parse(str);
            Event model = new Event()
            {
                EventTitle = events.EventTitle,
                EventLocation = events.EventLocation,
                EventDate = events.EventDate,
                EventTime = events.EventTime,
                EventDuration = events.EventDuration,
                EventDescription = events.EventDescription,
                EventDetails = events.EventDetails,
                EventType = events.EventType,
                EventInvite = events.EventInvite,
                UserId = id
            };
            using (var context = new BookBuffetEntities())
            {
                context.Event.Add(model);
                context.SaveChanges();
            }
        }

        public List<EventDTO> GetEventInvite(int id)
        {
            BookBuffetEntities databaseContext = new BookBuffetEntities();

            string email = databaseContext.User.Single(x => x.UserId == id).UserEmailId;

            string[] strInvite = databaseContext.Event.AsEnumerable().Select(s => s.EventInvite).ToArray<string>();

            List<Event> events=null;

            for (int i = 0; i < strInvite.Length; i++)
            {
                if (strInvite[i] != null)
                {
                    string[] invite = strInvite[i].Split(',');
                    for (int j = 0; j < invite.Length; j++)
                    {
                        if (invite[j] == email)
                        {
                            string check = invite[j];
                            events = databaseContext.Event.Where(x => x.EventInvite.Contains(check)).ToList();

                            goto end;
                        }
                    }
                }
            }
            end:
            List<EventDTO> model = new List<EventDTO>();
            if (events != null)
            {
                foreach (var item in events)
                {
                    EventDTO obj = new EventDTO()
                    {
                        EventDate = item.EventDate,
                        EventDescription = item.EventDescription,
                        EventDetails = item.EventDetails,
                        EventDuration = item.EventDuration,
                        EventId = item.EventId,
                        EventInvite = item.EventInvite,
                        EventLocation = item.EventLocation,
                        EventTime = item.EventTime,
                        EventTitle = item.EventTitle,
                        EventType = item.EventType,
                        UserId = item.UserId
                    };
                    model.Add(obj);
                }
            }
            return model;
        }

        public List<EventDTO> GetfutureEvent()
        {
            var databaseContext = new BookBuffetEntities();
            List<Event> events = new List<Event>();
            events = databaseContext.Event.
                            Where(start => start.EventDate > DateTime.Now
                            && start.EventType == "Public").ToList();
            List<EventDTO> model = new List<EventDTO>();
            foreach (var item in events)
            {
                EventDTO obj = new EventDTO()
                {
                    EventDate = item.EventDate,
                    EventDescription = item.EventDescription,
                    EventDetails = item.EventDetails,
                    EventDuration = item.EventDuration,
                    EventId = item.EventId,
                    EventInvite = item.EventInvite,
                    EventLocation = item.EventLocation,
                    EventTime = item.EventTime,
                    EventTitle = item.EventTitle,
                    EventType = item.EventType,
                    UserId = item.UserId
                };
                model.Add(obj);
            }
            return model;
        }

        public List<EventDTO> GetpastEvent()
        {
            BookBuffetEntities databaseContext = new BookBuffetEntities();
            List<Event> events = new List<Event>();
            events = databaseContext.Event.
                            Where(start => start.EventDate < DateTime.Now
                            && start.EventType == "Public").ToList();

            List<EventDTO> model = new List<EventDTO>();
            foreach (var item in events)
            {
                EventDTO obj = new EventDTO()
                {
                    EventDate = item.EventDate,
                    EventDescription = item.EventDescription,
                    EventDetails = item.EventDetails,
                    EventDuration = item.EventDuration,
                    EventId = item.EventId,
                    EventInvite = item.EventInvite,
                    EventLocation = item.EventLocation,
                    EventTime = item.EventTime,
                    EventTitle = item.EventTitle,
                    EventType = item.EventType,
                    UserId = item.UserId
                };
                model.Add(obj);
            }
            return model;
        }

        public void UpdateEvent(int Eventid, EventDTO events)
        {
            using (var context = new BookBuffetEntities())
            {
                var _event = context.Event.FirstOrDefault(e => e.EventId == Eventid);

                if (_event != null)
                {
                    _event.EventTitle = events.EventTitle;
                    _event.EventType = events.EventType;
                    _event.EventDate = events.EventDate;
                    _event.EventDescription = events.EventDescription;
                    _event.EventDetails = events.EventDetails;
                    _event.EventDuration = events.EventDuration;
                    _event.EventInvite = events.EventInvite;
                    _event.EventLocation = events.EventLocation;
                    _event.EventTime = events.EventTime;
                }
                context.SaveChanges();
            };
        }

        public EventDTO GetEvent(int id)
        {
            BookBuffetEntities databaseContext = new BookBuffetEntities();
            Event item= databaseContext.Event.Single(eventid => eventid.EventId == id);
            EventDTO model = new EventDTO()
            {
                EventDate = item.EventDate,
                EventDescription = item.EventDescription,
                EventDetails = item.EventDetails,
                EventDuration = item.EventDuration,
                EventId = item.EventId,
                EventInvite = item.EventInvite,
                EventLocation = item.EventLocation,
                EventTime = item.EventTime,
                EventTitle = item.EventTitle,
                EventType = item.EventType,
                UserId = item.UserId
            };
            return model;
        }

        public List<EventDTO> GetEventByUser(string str)
        {
            int id = int.Parse(str);
            BookBuffetEntities databaseContext = new BookBuffetEntities();
            List<Event> events;
            if (id == 0)
            {
                events = databaseContext.Event.Where(start => start.EventDate > DateTime.Now).ToList();
            }
            else
            {
                events = databaseContext.Event.Where(start => start.EventDate > DateTime.Now && start.UserId == id).ToList();
            }

            List<EventDTO> model = new List<EventDTO>();
            foreach (var item in events)
            {
                EventDTO obj = new EventDTO()
                {
                    EventDate = item.EventDate,
                    EventDescription = item.EventDescription,
                    EventDetails = item.EventDetails,
                    EventDuration = item.EventDuration,
                    EventId = item.EventId,
                    EventInvite = item.EventInvite,
                    EventLocation = item.EventLocation,
                    EventTime = item.EventTime,
                    EventTitle = item.EventTitle,
                    EventType = item.EventType,
                    UserId = item.UserId
                };
                model.Add(obj);
            }
            return model;
        }

        public List<EventDTO> GetAllUserEvent(string str)
        {
            BookBuffetEntities databaseContext = new BookBuffetEntities();
            List<Event> events= databaseContext.Event.Where(x => x.UserId.ToString() == str).ToList();
            List<EventDTO> model = new List<EventDTO>();
            foreach (var item in events)
            {
                EventDTO obj = new EventDTO()
                {
                    EventDate = item.EventDate,
                    EventDescription = item.EventDescription,
                    EventDetails = item.EventDetails,
                    EventDuration = item.EventDuration,
                    EventId = item.EventId,
                    EventInvite = item.EventInvite,
                    EventLocation = item.EventLocation,
                    EventTime = item.EventTime,
                    EventTitle = item.EventTitle,
                    EventType = item.EventType,
                    UserId = item.UserId
                };
                model.Add(obj);
            }
            return model;
        }

    }

}
