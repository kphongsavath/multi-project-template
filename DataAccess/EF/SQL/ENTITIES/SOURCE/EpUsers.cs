using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.DataAccess.EF.Sql.Entities
{
    [Table("EpUsers", Schema = "Source")]
    public partial class EpUsers
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string UserName { get; set; } = null!;
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        [Required]
        public bool? Active { get; set; }
        [StringLength(200)]
        public string? Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
