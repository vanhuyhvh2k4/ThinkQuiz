using Mapster;
using ThinkQuiz.Application.Class.Commands.Create;
using ThinkQuiz.Application.Class.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.Create;
using ThinkQuiz.Contracts.Class.GetClasses;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Api.Common.Mapping
{
    public class ClassMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Guid teacherId, CreateClassRequest createClassRequest), CreateClassCommand>()
                .Map(dest => dest.teacherId, src => src.teacherId)
                .Map(dest => dest, src => src.createClassRequest);

            config.NewConfig<Class, CreateClassResponse>()
                .Map(dest => dest.Data, src => src)
                .Map(dest => dest.Data.CreatedAt, src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.UpdatedAt, src => src.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

            config.NewConfig<(Guid teacherId, GetClassesRequest request), GetClassesQuery>()
                .Map(dest => dest.teacherId, src => src.teacherId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<List<Class>, GetClassesResponse>()
                .Map(dest => dest.Data.Classes, src => src);
        }
    }
}

