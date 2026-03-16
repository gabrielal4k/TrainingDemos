using System;
using System.Collections.Generic;
using System.Text;
using Todo.Contracts.Entities;
using Todo.Contracts.Interface.Data;
using Todo.Contracts.Interface.Service;

namespace Todo.Service.Module;

public class EventService(IEvents _event) : IEventService
{
    //IEvents _event;
    //public EventService(Event xevent)
    //{
    //    xevent = _event;
    //}

    public Event AddDTOEvent(Event dto)
    {
        if (dto is null)
            return dto;

        _event.AddEvent(dto);

        return dto;
    }

    public List<Event> GetDTOEvents()
    {
       return  _event.GetEvents();
    }

    public Event GetDTOEvent(int eventID)
    {
        if (eventID < 1)
            return null;

        return _event.GetEvent(eventID);
    }

}
