using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.DataAccess.EF.Sql.Entities
{
    [Keyless]
    public partial class VsEpConfiguration
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? FilterName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProcessingDate { get; set; }
        [StringLength(500)]
        public string? Param1 { get; set; }
        [StringLength(500)]
        public string? Param2 { get; set; }
        [StringLength(500)]
        public string? Param3 { get; set; }
        [StringLength(500)]
        public string? Param4 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(25)]
        public string? CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(25)]
        public string? ModifiedUser { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
    }
}
