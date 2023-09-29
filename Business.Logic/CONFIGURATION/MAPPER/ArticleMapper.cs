using AutoMapper;

namespace $ext_safeprojectname$.Business.Logic.Configuration.Mapper
{
    internal class ArticleMapper : Profile
    {
        public ArticleMapper()
        {
            CreateMap<DataAccess.EF.Sql.Entities.ArticleData, Common.Model.Articles>();
        }
    }
}
