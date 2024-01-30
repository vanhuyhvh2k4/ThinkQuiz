using Mapster;
using ThinkQuiz.Application.Classes.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.Common;
using ThinkQuiz.Contracts.Class.GetClass;
using ThinkQuiz.Contracts.Class.GetClasses;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Api.Common.Mapping.ClassMapping
{
    public class GetClassMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Class, ClassResponse>()
               .Map(dest => dest.Id, src => src.Id.ToString())
               .Map(dest => dest.Teacher.Id, src => src.Teacher.Id)
               .Map(dest => dest.Teacher.Name, src => src.Teacher.User.FullName)
               .Map(dest => dest.Teacher.Email, src => src.Teacher.User.Email)
               .Map(dest => dest.Teacher.Phone, src => src.Teacher.User.Phone)
               .Map(dest => dest.Teacher.Position, src => src.Teacher.Position)
               .Map(dest => dest.Teacher.SchoolInformation, src => src.Teacher.SchoolInformation)
               .Map(dest => dest.Teacher.Phone, src => src.Teacher.User.Phone);

            // Get classes of teacher
            config.NewConfig<(GetClassesRequest request, Guid teacherId), GetClassesQuery>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<List<Class>, GetClassesResponse>()
                .Map(dest => dest.Data.Classes, src => src);

            // Get class by id

            config.NewConfig<Class, GetClassResponse>()
                .Map(dest => dest.Class, src => src);
        }
    }
}

