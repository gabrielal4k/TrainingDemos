using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleCrud.Contracts.DTO;

public class AppSettings
{
    [Required]
    public required string DBConnectionString { get; set; }
    [Required]
    public bool MultiTenantMode { get; set; }
}
