using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCrud.Contracts.DTO;

public class ResponseBox
{

    public  string ResponseText { get; set; } = string.Empty;
    public  bool Error { get; set; } = false;
    public object? Data { get; set; } = null;

}
