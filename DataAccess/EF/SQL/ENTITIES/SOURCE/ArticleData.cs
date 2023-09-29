using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.DataAccess.EF.Sql.Entities
{
    [Table("ArticleData", Schema = "Source")]
    [Index(nameof(PhCategory), Name = "IDX_CAT")]
    [Index(nameof(Masterstyle), Name = "IDX_MASTERSTYLE")]
    [Index(nameof(PhSubcategory), Name = "IDX_SUBCAT")]
    [Index(nameof(Mpid), Name = "UK_Mpid", IsUnique = true)]
    public partial class ArticleData
    {
        [Key]
        public int Id { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string Mpid { get; set; } = null!;
        [StringLength(73)]
        [Unicode(false)]
        public string? MpidDesc { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? ProcessIndicator { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? KeyItemFlag { get; set; }
        [StringLength(18)]
        [Unicode(false)]
        public string? StyleNumber { get; set; }
        [StringLength(42)]
        [Unicode(false)]
        public string? StyleDesc { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string? Masterstyle { get; set; }
        [StringLength(42)]
        [Unicode(false)]
        public string? MasterstyleDesc { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string? ArticleCategory { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? MerchItemSegment { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? MerchItemSegmentDesc { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? PlanOrgVss { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? PlanOrgVsb { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? PlanOrgPink { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? PlanOrgVsd { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? PlanOrgVsbaIeg { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? PlanOrgFlag { get; set; }
        [StringLength(18)]
        [Unicode(false)]
        public string? SapSectorCode { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? SapSectorDesc { get; set; }
        [StringLength(18)]
        [Unicode(false)]
        public string? SapCategoryCode { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? SapCategoryDesc { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string? SapCollection { get; set; }
        [StringLength(18)]
        [Unicode(false)]
        public string? SapClassCode { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? SapClassDesc { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string? SapSubclassCode { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? SapSubclassDesc { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string? SapSubbrandCode { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? SapSubbrandDesc { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string? SapEmotionalSpace { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SapEmotionalSpaceDesc { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PhBrand { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string? PhBrandDesc { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PhCategory { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string? PhCategoryDesc { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PhSubcategory { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string? PhSubcategoryDesc { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PhBob { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string? PhBobDesc { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? PhPlangroup { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string? PhPlangroupDesc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string CreateUser { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ModifiedUser { get; set; }
    }
}
