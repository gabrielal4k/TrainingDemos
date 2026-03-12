using System;
using System.Collections.Generic;
using System.Text;
using Todo.Contracts.Entities;
using Todo.Contracts.Interface.Data;

namespace Todo.DA.Context.Data;

public class Events : IEvents
{
    private readonly TodoDBContext _context;

    public Events(TodoDBContext context)
    {
        _context = context;
    }

    public async Task<Event> AddEventAsync(Event dto)
    {
        _context.Events.Add(dto);
        await _context.SaveChangesAsync();

        return dto;
    }

    public Event AddEvent(Event dto)
    {
        _context.Events.Add(dto);
        _context.SaveChanges();

        return dto;
    }
}
