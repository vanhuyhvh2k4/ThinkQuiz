using Mapster;
using ThinkQuiz.Application.Class.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.Common;
using ThinkQuiz.Contracts.Class.GetClass;
using ThinkQuiz.Contracts.Class.GetClasses;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Api.Common.Mapping.Class
{
    public class GetClassMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<ClassAggregate, ClassResponse>()
               .Map(dest => dest.Id, src => src.Id.ToString())
               .Map(dest => dest.Teacher.Id, src => src.Teacher.Id)
               .Map(dest => dest.Teacher.Name, src => src.Teacher.User.FullName)
               .Map(dest => dest.Teacher.Email, src => src.Teacher.User.Email)
               .Map(dest => dest.Teacher.Phone, src => src.Teacher.User.Phone)
               .Map(dest => dest.Teacher.Position, src => src.Teacher.Position)
               .Map(dest => dest.Teacher.SchoolInformation, src => src.Teacher.SchoolInformation)
               .Map(dest => dest.Teacher.Phone, src => src.Teacher.User.Phone)
               .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
               .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));


            // Get classes of teacher
            config.NewConfig<(GetClassesRequest request, Guid teacherId), GetClassesQuery>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<List<ClassAggregate>, GetClassesResponse>()
                .Map(dest => dest.Data.Classes, src => src);

            // Get class by id

            config.NewConfig<ClassAggregate, GetClassResponse>()
                .Map(dest => dest.Class, src => src);
        }
    }
}

