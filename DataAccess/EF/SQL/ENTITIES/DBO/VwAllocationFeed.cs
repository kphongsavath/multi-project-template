using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.DataAccess.EF.Sql.Entities
{
    [Keyless]
    public partial class VwAllocationFeed
    {
        [Column("PRODUCT_NAME")]
        [StringLength(50)]
        public string? ProductName { get; set; }
        [Column("ORGANIZATION_NAME")]
        [StringLength(10)]
        [Unicode(false)]
        public string OrganizationName { get; set; } = null!;
        [Column("TIME_NAME", TypeName = "datetime")]
        public DateTime? TimeName { get; set; }
        [Column("TTLSLS_UNIT_TP1", TypeName = "decimal(38, 10)")]
        public decimal? TtlslsUnitTp1 { get; set; }
        [Column("GVWY_UNT_TP1", TypeName = "decimal(38, 10)")]
        public decimal? GvwyUntTp1 { get; set; }
        [Column("CLRSLS_UNIT_TP1", TypeName = "decimal(38, 10)")]
        public decimal ClrslsUnitTp1 { get; set; }
    }
}
