using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Contracts.Entities;

namespace Todo.DA;

public class TodoDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
}
