using System;
using System.Collections.Generic;
using System.Text;
using Todo.Contracts.Entities;

namespace Todo.Contracts.Interface.Data;

public interface IEvents
{
    Task<Event> AddEventAsync(Event dto);
    Event AddEvent(Event dto);
}
