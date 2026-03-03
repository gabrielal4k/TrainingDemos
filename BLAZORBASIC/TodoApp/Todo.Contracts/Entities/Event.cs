using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Todo.Contracts.Entities;

public class Event
{
    [Key]
    public int EventID { get; set; }
    [StringLength(100), Required]
    public string Title { get; set; } = string.Empty;
    [StringLength(255), Required]
    public string Description { get; set; } = string.Empty;
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public bool AllDay { get; set; }
    public DateTime CreatedAt { get; set; }
}
