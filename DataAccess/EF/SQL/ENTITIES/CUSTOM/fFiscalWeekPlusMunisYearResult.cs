#nullable enable

using VS;

namespace $ext_safeprojectname$.DataAccess.EF.Sql.Entities.Custom
{
    public partial class FiscalWeekPlusMunisYearResult
    {
        public int? FISCAL_YEAR { get; set; }
        public DateTime? WEEK_ENDING { get; set; }
        public string? FISCAL_WEEK_NUMBER { get; set; }
        public string? FISCAL_WEEK { get; set; }
        public string? CURRENT_FISCAL_WEEK_NUMBER { get; set; }
        public string? CURRENT_FISCAL_WEEK { get; set; }
        public DateTime? CurrentFiscalWeek { get; set; }
        public int? CurrentFiscalYear { get; set; }
        public string? LAST_FISCAL_WEEK_NUMBER { get; set; }
        public string? LAST_FISCAL_WEEK { get; set; }
        public DateTime? LastFiscalWeek { get; set; }
        public int? LastFiscalWeekYear { get; set; }
        public string? PREV_FISCAL_WEEK_NUMBER { get; set; }
        public string? PREV_FISCAL_WEEK { get; set; }
        public DateTime? PrevFiscalWeek { get; set; }
        public int? PrevFiscalWeekYear { get; set; }
    }
}
