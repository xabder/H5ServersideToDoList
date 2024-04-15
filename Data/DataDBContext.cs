using System;
using Microsoft.EntityFrameworkCore;
using H5ServersideToDoList.Data.Models.Entities;

namespace H5ServersideToDoList.Data
{
    public class DataDBContext(DbContextOptions<DataDBContext> options) : DbContext(options)
    {
        public DbSet<Cpr> Cprs { get; set; }
        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}

