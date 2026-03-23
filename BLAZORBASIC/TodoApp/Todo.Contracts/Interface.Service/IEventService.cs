using System;
using System.Collections.Generic;
using System.Text;
using Todo.Contracts.DTO;
using Todo.Contracts.Entities;

namespace Todo.Contracts.Interface.Service;

public interface IEventService
{
    DTOEvent AddDTOEvent(DTOEvent dto);
    DTOEvent EditDTOEvent(DTOEvent dto);
    ResultResponse DeleteDTOEvent(int eventID);
    List<DTOEvent> GetDTOEvents();
    Event GetDTOEvent(int eventID);
}
