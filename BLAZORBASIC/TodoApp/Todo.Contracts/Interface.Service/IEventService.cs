using System;
using System.Collections.Generic;
using System.Text;
using Todo.Contracts.Entities;

namespace Todo.Contracts.Interface.Service;

public interface IEventService
{
    Event AddDTOEvent(Event dto);
    List<Event> GetDTOEvents();
    Event GetDTOEvent(int eventID);
}
