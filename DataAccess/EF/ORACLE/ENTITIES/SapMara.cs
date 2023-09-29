using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.DataAccess.EF.Oracle.Entities
{
    [Table("SAP_MARA")]
    [Index(nameof(ZzPlmid), Name = "ZZ_SAP_MARA_IDX2")]
    [Index(nameof(ZzChoice), Name = "ZZ_SAP_MARA_IDX3")]
    public partial class SapMara
    {
        [Key]
        [Column("MATNR")]
        [StringLength(18)]
        [Unicode(false)]
        public string Matnr { get; set; } = null!;
        [Column("ERSDA")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Ersda { get; set; }
        [Column("ERNAM")]
        [StringLength(12)]
        [Unicode(false)]
        public string? Ernam { get; set; }
        [Column("LAEDA")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Laeda { get; set; }
        [Column("AENAM")]
        [StringLength(12)]
        [Unicode(false)]
        public string? Aenam { get; set; }
        [Column("LVORM")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Lvorm { get; set; }
        [Column("MTART")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Mtart { get; set; }
        [Column("ZEINR")]
        [StringLength(22)]
        [Unicode(false)]
        public string? Zeinr { get; set; }
        [Column("MATKL")]
        [StringLength(9)]
        [Unicode(false)]
        public string? Matkl { get; set; }
        [Column("BISMT")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Bismt { get; set; }
        [Column("MEINS")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Meins { get; set; }
        [Column("BSTME")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Bstme { get; set; }
        [Column("ZEIAR")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Zeiar { get; set; }
        [Column("ZEIVR")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Zeivr { get; set; }
        [Column("ZEIFO")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Zeifo { get; set; }
        [Column("AESZN")]
        [StringLength(6)]
        [Unicode(false)]
        public string? Aeszn { get; set; }
        [Column("BLATT")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Blatt { get; set; }
        [Column("BLANZ")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Blanz { get; set; }
        [Column("FERTH")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Ferth { get; set; }
        [Column("FORMT")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Formt { get; set; }
        [Column("GROES")]
        [StringLength(32)]
        [Unicode(false)]
        public string? Groes { get; set; }
        [Column("WRKST")]
        [StringLength(48)]
        [Unicode(false)]
        public string? Wrkst { get; set; }
        [Column("NORMT")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Normt { get; set; }
        [Column("LABOR")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Labor { get; set; }
        [Column("EKWSL")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Ekwsl { get; set; }
        [Column("BRGEW")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Brgew { get; set; }
        [Column("NTGEW")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Ntgew { get; set; }
        [Column("GEWEI")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Gewei { get; set; }
        [Column("VOLUM")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Volum { get; set; }
        [Column("VOLEH")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Voleh { get; set; }
        [Column("BEHVO")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Behvo { get; set; }
        [Column("RAUBE")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Raube { get; set; }
        [Column("TEMPB")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Tempb { get; set; }
        [Column("TRAGR")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Tragr { get; set; }
        [Column("STOFF")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Stoff { get; set; }
        [Column("SPART")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Spart { get; set; }
        [Column("KUNNR")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Kunnr { get; set; }
        [Column("WESCH")]
        [StringLength(13)]
        [Unicode(false)]
        public string? Wesch { get; set; }
        [Column("BWVOR")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Bwvor { get; set; }
        [Column("BWSCL")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Bwscl { get; set; }
        [Column("SAISO")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Saiso { get; set; }
        [Column("ETIAR")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Etiar { get; set; }
        [Column("ETIFO")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Etifo { get; set; }
        [Column("EAN11")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Ean11 { get; set; }
        [Column("NUMTP")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Numtp { get; set; }
        [Column("LAENG")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Laeng { get; set; }
        [Column("BREIT")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Breit { get; set; }
        [Column("HOEHE")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Hoehe { get; set; }
        [Column("MEABM")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Meabm { get; set; }
        [Column("PRDHA")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Prdha { get; set; }
        [Column("CADKZ")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Cadkz { get; set; }
        [Column("QMPUR")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Qmpur { get; set; }
        [Column("ERGEW")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Ergew { get; set; }
        [Column("ERGEI")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Ergei { get; set; }
        [Column("ERVOL")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Ervol { get; set; }
        [Column("ERVOE")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Ervoe { get; set; }
        [Column("GEWTO")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Gewto { get; set; }
        [Column("VOLTO")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Volto { get; set; }
        [Column("VABME")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Vabme { get; set; }
        [Column("XCHPF")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Xchpf { get; set; }
        [Column("VHART")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Vhart { get; set; }
        [Column("FUELG")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Fuelg { get; set; }
        [Column("STFAK")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Stfak { get; set; }
        [Column("MAGRV")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Magrv { get; set; }
        [Column("BEGRU")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Begru { get; set; }
        [Column("DATAB")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Datab { get; set; }
        [Column("LIQDT")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Liqdt { get; set; }
        [Column("SAISJ")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Saisj { get; set; }
        [Column("PLGTP")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Plgtp { get; set; }
        [Column("MLGUT")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Mlgut { get; set; }
        [Column("EXTWG")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Extwg { get; set; }
        [Column("SATNR")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Satnr { get; set; }
        [Column("ATTYP")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Attyp { get; set; }
        [Column("PMATA")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Pmata { get; set; }
        [Column("MSTAE")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Mstae { get; set; }
        [Column("MSTAV")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Mstav { get; set; }
        [Column("MSTDE")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Mstde { get; set; }
        [Column("MSTDV")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Mstdv { get; set; }
        [Column("TAKLV")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Taklv { get; set; }
        [Column("RBNRM")]
        [StringLength(9)]
        [Unicode(false)]
        public string? Rbnrm { get; set; }
        [Column("MHDRZ")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Mhdrz { get; set; }
        [Column("MHDHB")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Mhdhb { get; set; }
        [Column("MHDLP")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Mhdlp { get; set; }
        [Column("INHME")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Inhme { get; set; }
        [Column("INHAL")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Inhal { get; set; }
        [Column("VPREH")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Vpreh { get; set; }
        [Column("INHBR")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Inhbr { get; set; }
        [Column("KZUMW")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Kzumw { get; set; }
        [Column("KOSCH")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Kosch { get; set; }
        [Column("SPROF")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Sprof { get; set; }
        [Column("NRFHG")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Nrfhg { get; set; }
        [Column("SAITY")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Saity { get; set; }
        [Column("PROFL")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Profl { get; set; }
        [Column("IHIVI")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Ihivi { get; set; }
        [Column("ILOOS")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Iloos { get; set; }
        [Column("KZGVH")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Kzgvh { get; set; }
        [Column("XGCHP")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Xgchp { get; set; }
        [Column("IPRKZ")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Iprkz { get; set; }
        [Column("RDMHD")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Rdmhd { get; set; }
        [Column("PRZUS")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Przus { get; set; }
        [Column("MTPOS_MARA")]
        [StringLength(4)]
        [Unicode(false)]
        public string? MtposMara { get; set; }
        [Column("GENNR")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Gennr { get; set; }
        [Column("RMATP")]
        [StringLength(18)]
        [Unicode(false)]
        public string? Rmatp { get; set; }
        [Column("HUTYP_DFLT")]
        [StringLength(4)]
        [Unicode(false)]
        public string? HutypDflt { get; set; }
        [Column("PILFERABLE")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Pilferable { get; set; }
        [Column("WHSTC")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Whstc { get; set; }
        [Column("WHMATGR")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Whmatgr { get; set; }
        [Column("HNDLCODE")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Hndlcode { get; set; }
        [Column("HAZMAT")]
        [StringLength(1)]
        [Unicode(false)]
        public string? Hazmat { get; set; }
        [Column("HUTYP")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Hutyp { get; set; }
        [Column("TARE_VAR")]
        [StringLength(1)]
        [Unicode(false)]
        public string? TareVar { get; set; }
        [Column("MAXC")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Maxc { get; set; }
        [Column("MAXC_TOL")]
        [StringLength(3)]
        [Unicode(false)]
        public string? MaxcTol { get; set; }
        [Column("MAXL")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Maxl { get; set; }
        [Column("MAXB")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Maxb { get; set; }
        [Column("MAXH")]
        [StringLength(16)]
        [Unicode(false)]
        public string? Maxh { get; set; }
        [Column("MAXDIM_UOM")]
        [StringLength(3)]
        [Unicode(false)]
        public string? MaxdimUom { get; set; }
        [Column("HERKL")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Herkl { get; set; }
        [Column("MFRGR")]
        [StringLength(8)]
        [Unicode(false)]
        public string? Mfrgr { get; set; }
        [Column("QQTIME")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Qqtime { get; set; }
        [Column("QQTIMEUOM")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Qqtimeuom { get; set; }
        [Column("QGRP")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Qgrp { get; set; }
        [Column("SERIAL")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Serial { get; set; }
        [Column("PS_SMARTFORM")]
        [StringLength(30)]
        [Unicode(false)]
        public string? PsSmartform { get; set; }
        [Column("ADPROF")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Adprof { get; set; }
        [Column("ALLOW_PMAT_IGNO")]
        [StringLength(1)]
        [Unicode(false)]
        public string? AllowPmatIgno { get; set; }
        [Column("BSTAT")]
        [StringLength(2)]
        [Unicode(false)]
        public string? Bstat { get; set; }
        [Column("FREE_CHAR")]
        [StringLength(18)]
        [Unicode(false)]
        public string? FreeChar { get; set; }
        [Column("CARE_CODE")]
        [StringLength(16)]
        [Unicode(false)]
        public string? CareCode { get; set; }
        [Column("BRAND_ID")]
        [StringLength(4)]
        [Unicode(false)]
        public string? BrandId { get; set; }
        [Column("FIBER_CODE1")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberCode1 { get; set; }
        [Column("FIBER_PART1")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberPart1 { get; set; }
        [Column("FIBER_CODE2")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberCode2 { get; set; }
        [Column("FIBER_PART2")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberPart2 { get; set; }
        [Column("FIBER_CODE3")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberCode3 { get; set; }
        [Column("FIBER_PART3")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberPart3 { get; set; }
        [Column("FIBER_CODE4")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberCode4 { get; set; }
        [Column("FIBER_PART4")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberPart4 { get; set; }
        [Column("FIBER_CODE5")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberCode5 { get; set; }
        [Column("FIBER_PART5")]
        [StringLength(3)]
        [Unicode(false)]
        public string? FiberPart5 { get; set; }
        [Column("FASHGRD")]
        [StringLength(4)]
        [Unicode(false)]
        public string? Fashgrd { get; set; }
        [Column("ZZ_PLMID")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ZzPlmid { get; set; }
        [Column("ZZ_STYLE")]
        [StringLength(18)]
        [Unicode(false)]
        public string? ZzStyle { get; set; }
        [Column("ZZ_STYLEID")]
        [StringLength(15)]
        [Unicode(false)]
        public string? ZzStyleid { get; set; }
        [Column("ZZ_CHOICE")]
        [StringLength(4)]
        [Unicode(false)]
        public string? ZzChoice { get; set; }
        [Column("ZZ_SUBRAND")]
        [StringLength(2)]
        [Unicode(false)]
        public string? ZzSubrand { get; set; }
        [Column("ZZ_SUBRAND1")]
        [StringLength(4)]
        [Unicode(false)]
        public string? ZzSubrand1 { get; set; }
        [Column("ZZ_SUBCLASS")]
        [StringLength(2)]
        [Unicode(false)]
        public string? ZzSubclass { get; set; }
        [Column("ZZ_SUBCLASS1")]
        [StringLength(4)]
        [Unicode(false)]
        public string? ZzSubclass1 { get; set; }
        [Column("ZZ_HAZMWEI")]
        [StringLength(8)]
        [Unicode(false)]
        public string? ZzHazmwei { get; set; }
        [Column("ZZ_TRACK")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzTrack { get; set; }
        [Column("ZZ_SHAREF")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzSharef { get; set; }
        [Column("ZZ_DISCONFL")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzDisconfl { get; set; }
        [Column("ZZ_CLEAR")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzClear { get; set; }
        [Column("ZZ_PSET")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzPset { get; set; }
        [Column("ZZ_EMBEL")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzEmbel { get; set; }
        [Column("ZZ_DISCON")]
        [StringLength(8)]
        [Unicode(false)]
        public string? ZzDiscon { get; set; }
        [Column("ZZ_PRPROM")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzPrprom { get; set; }
        [Column("ZZ_EMDIAL")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzEmdial { get; set; }
        [Column("ZZ_STEAM")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzSteam { get; set; }
        [Column("ZZ_SECTAG")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzSectag { get; set; }
        [Column("ZZ_TEST")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzTest { get; set; }
        [Column("ZZ_LONGSKU")]
        [StringLength(38)]
        [Unicode(false)]
        public string? ZzLongsku { get; set; }
        [Column("ZZ_CHOICEID")]
        [StringLength(15)]
        [Unicode(false)]
        public string? ZzChoiceid { get; set; }
        [Column("ZZ_PLANSTAT")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzPlanstat { get; set; }
        [Column("ZZ_PROMO")]
        [StringLength(1)]
        [Unicode(false)]
        public string? ZzPromo { get; set; }
        [Column("ZZ_STYLEID1")]
        [StringLength(19)]
        [Unicode(false)]
        public string? ZzStyleid1 { get; set; }
        [Column("ZZ_CHOICEID1")]
        [StringLength(19)]
        [Unicode(false)]
        public string? ZzChoiceid1 { get; set; }
        [Column("SRC_LAST_UPD_TS", TypeName = "DATE")]
        public DateTime? SrcLastUpdTs { get; set; }
        [Column("MANDT")]
        [StringLength(3)]
        [Unicode(false)]
        public string? Mandt { get; set; }
        [Column("LAST_UPDATE_TS", TypeName = "DATE")]
        public DateTime? LastUpdateTs { get; set; }
        [Column("ZZ_PLMIDCHOICE")]
        [StringLength(54)]
        [Unicode(false)]
        public string? ZzPlmidchoice { get; set; }
        [Column("ISVALID")]
        [Precision(1)]
        public bool? Isvalid { get; set; }
    }
}
