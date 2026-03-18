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
    public Event EditEvent(Event dto)
    {
        var mDTO = _context.Events.Find(dto.EventID);

        if (mDTO is null)
            return mDTO;

        mDTO.Title = dto.Title;
        mDTO.Description = dto.Description;
        mDTO.Start = dto.Start;
        mDTO.End = dto.End;
        mDTO.AllDay = dto.AllDay;

        _context.Update(mDTO);
        _context.SaveChanges();

        return mDTO;
    }

    public bool DeleteEvent(int eventID)
    {
        var mDTO = _context.Events.Find(eventID);

        if (mDTO is null)
            return false;

        _context.Events.Remove(mDTO);   
        _context.SaveChanges();

        return true;
    }



    public List<Event> GetEvents()
    {
        var dtos = _context.Events.OrderByDescending(e => e.EventID).ToList();

        return dtos;
    }

    public Event GetEvent(int eventID)
    {
        var dto = _context.Events.Find(eventID);

        return dto;
    }
}
