using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Contracts.DTO;

public class ResultResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}
