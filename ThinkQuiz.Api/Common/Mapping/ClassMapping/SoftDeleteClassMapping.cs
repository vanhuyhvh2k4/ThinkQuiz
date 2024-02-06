using Mapster;
using ThinkQuiz.Application.Classes.Commands.SoftDeleteClass;

namespace ThinkQuiz.Api.Common.Mapping.ClassMapping
{
    public class SoftDeleteClassMapping : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Guid teacherId, Guid classId), SoftDeleteClassCommand>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest.ClassId, src => src.classId);
        }
    }
}

