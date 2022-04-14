using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessFacades
{
    public class EventFacade : FacadeBase, IEventFacade
    {
        private readonly IEventBDC eventBDC;

        public EventFacade()
            : base(BusinessFacadeType.EventFacade)
        {
            eventBDC = (IEventBDC)BusinessLayerFactory.Instance.Create(BusinessLayerType.EventBDC);
        }

        public void AddEvent(EventDTO events, string str)
        {
            eventBDC.AddEvent(events,str);
        }

        public EventDTO GetEvent(int id)
        {
            return eventBDC.GetEvent(id);
        }

        public List<EventDTO> GetEventByUser(string id)
        {
            return eventBDC.GetEventByUser(id);
        }

        public List<EventDTO> GetEventInvite(int id)
        {
            return eventBDC.GetEventInvite(id);
        }

        public List<EventDTO> GetfutureEvent()
        {
            return eventBDC.GetfutureEvent();
        }

        public List<EventDTO> GetpastEvent()
        {
            return eventBDC.GetpastEvent();
        }

        public void UpdateEvent(int Eventid, EventDTO events)
        {
            eventBDC.UpdateEvent(Eventid, events);
        }

        public List<EventDTO> GetAllUserEvent(string str)
        {
            return eventBDC.GetAllUserEvent(str);
        }
    }

}
