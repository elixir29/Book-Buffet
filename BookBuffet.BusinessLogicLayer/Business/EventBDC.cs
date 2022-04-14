

using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.BusinessLogicLayer
{
    public class EventBDC : BusinessLayerBase, IEventBDC
    {

        private readonly IDataAccessFactory dacFactory;
        public EventBDC()
            : base(BusinessLayerType.EventBDC)
        {
            dacFactory = DataAccessFactory.Instance;
        }

        public EventBDC(IDataAccessFactory dacFactory)
            : base(BusinessLayerType.EventBDC)
        {
            this.dacFactory = dacFactory;
        }


        public void AddEvent(EventDTO events, string str)
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            eventDAC.AddEvent(events,str);
        }

        public EventDTO GetEvent(int id)
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            return eventDAC.GetEvent(id);
        }

        public List<EventDTO> GetEventByUser(string id)
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            return eventDAC.GetEventByUser(id);
        }

        public List<EventDTO> GetEventInvite(int id)
        {
            IEventDAC eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            return eventDAC.GetEventInvite(id);          
        }

        public List<EventDTO> GetfutureEvent()
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            return eventDAC.GetfutureEvent();
        }

        public List<EventDTO> GetpastEvent()
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            return eventDAC.GetpastEvent();
        }

        public void UpdateEvent(int Eventid, EventDTO events)
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            eventDAC.UpdateEvent(Eventid, events);
        }

        public List<EventDTO> GetAllUserEvent(string str)
        {
            IEventDAC eventDAC = eventDAC = (IEventDAC)DataAccessFactory.Instance.Create(DataAccessType.EventDAC);
            return eventDAC.GetAllUserEvent(str);
        }
    }

}
