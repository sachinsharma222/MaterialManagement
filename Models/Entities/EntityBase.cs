using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public string CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public IdentityUser CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedById { get; set; }
        [ForeignKey("ModifiedById")]
        public IdentityUser ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
