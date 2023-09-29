using AutoMapper;
using System.Data;

namespace $ext_safeprojectname$.DataAccess.Configuration.AutoMapper
{
    internal class DataReaderProfile : Profile
    {

        /// <summary>
        /// When Using IDataReader, Create Maps to custom objects
        /// </summary>
        public DataReaderProfile()
        {
            //IDataReader to Object
            CreateMap<IDataReader, EF.Sql.Entities.Custom.FiscalWeekPlusMunisYearResult>();

        }
    }
}
