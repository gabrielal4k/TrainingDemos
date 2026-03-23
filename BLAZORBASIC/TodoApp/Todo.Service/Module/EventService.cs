using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using Todo.Contracts.DTO;
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

    public DTOEvent AddDTOEvent(DTOEvent dto)
    {
        if (dto is null)
            return dto;

        Event entt = new()
        {
            Title = dto.Title,
            Description = dto.Description,
            Start = dto.Start,
            End = dto.End,
            AllDay = dto.AllDay,
            CreatedAt = DateTime.Now
        };

        _event.AddEvent(entt);

        return dto;
    }
    public DTOEvent EditDTOEvent(DTOEvent dto)
    {
        if (dto is null)
            return dto;

        Event entt = new()
        {
            Title = dto.Title,
            Description = dto.Description,
            Start = dto.Start,
            End = dto.End,
            AllDay = dto.AllDay,
            CreatedAt = DateTime.Now
        };

        _event.AddEvent(entt);

        return dto;
    }

    public ResultResponse DeleteDTOEvent(int eventID)
    {
        if (eventID is 0)
            return new()
            {
                IsSuccess = false,
                Message = "EventID is required.",
            };

        _event.DeleteEvent(eventID);

        return new()
        {
            IsSuccess = true,
            Message = "Event deleted successfully.",
        };
    }


    public List<DTOEvent> GetDTOEvents()
    {
        var entt = _event.GetEvents();
        List<DTOEvent> listDTO = new ();

        foreach (var e in entt)
        {
            var dto = new DTOEvent()
            {
                Title = e.Title,
                Description = e.Description,
                Start = e.Start,
                End = e.End,
                AllDay = e.AllDay,
                CreatedAt = e.CreatedAt
            };

            listDTO.Add(dto);
        }

        return listDTO;
    }

    public Event GetDTOEvent(int eventID)
    {
        if (eventID < 1)
            return null;

        return _event.GetEvent(eventID);
    }

}
