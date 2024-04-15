using System;
using System.ComponentModel.DataAnnotations;

namespace H5ServersideToDoList.Data.Models.Entities
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public Guid IdentityId { get; set; }
    }
}

