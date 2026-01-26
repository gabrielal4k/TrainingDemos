using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleCrud.Contracts.DTO;

public class DTOStudent
{
    public int StudentId { get; set; }
    [Required]
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    [Required]
    public  string LastName { get; set; }
    [EmailAddress]
    [Required]
    public  string? Email { get; set; }
    public  string? Phone { get; set; }
    public  string? Address { get; set; }
}
