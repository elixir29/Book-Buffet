
using BookBuffet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public interface IEventFacade : IBusinessFacade
    {
        void AddEvent(EventDTO events, string str);
        
        List<EventDTO> GetEventInvite(int id);
        
        List<EventDTO> GetfutureEvent();

        List<EventDTO> GetpastEvent();

        void UpdateEvent(int Eventid, EventDTO events);
        
        EventDTO GetEvent(int id);
        
        List<EventDTO> GetEventByUser(string id);
        
        List<EventDTO> GetAllUserEvent(string str);
    }

}
