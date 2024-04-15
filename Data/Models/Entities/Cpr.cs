using System;
using System.ComponentModel.DataAnnotations;

namespace H5ServersideToDoList.Data.Models.Entities
{
    public class Cpr
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }

        public required string CprNumber { get; set; }

        public string UserMail { get; set; } = string.Empty;
    }
}
