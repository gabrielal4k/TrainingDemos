using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleCrud.Contracts.Entities;

public class Students
{
    [Key]
    public int StudentId { get; set; }
    [StringLength(100)]
    public required string FirstName { get; set; }
    [StringLength(100)]
    public string? MiddleName { get; set; }
    [StringLength(100)]
    public required string LastName { get; set; }
    [StringLength(150)]
    public required string Email { get; set; }
    [StringLength(15)]
    public required string Phone { get; set; }
    [StringLength(255)]
    public required string Address { get; set; }
}
