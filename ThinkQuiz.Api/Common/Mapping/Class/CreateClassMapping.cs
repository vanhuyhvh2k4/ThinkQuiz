using Mapster;
using ThinkQuiz.Application.Class.Commands.Create;
using ThinkQuiz.Contracts.Class.Create;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Api.Common.Mapping.Class
{
    public class CreateClassMapping : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            // Create class
            config.NewConfig<(Guid teacherId, CreateClassRequest createClassRequest), CreateClassCommand>()
                .Map(dest => dest.teacherId, src => src.teacherId)
                .Map(dest => dest, src => src.createClassRequest);

            config.NewConfig<ClassAggregate, CreateClassResponse>()
                .Map(dest => dest.Data, src => src)
                .Map(dest => dest.Data.CreatedAt, src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.UpdatedAt, src => src.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

        }
    }
}

