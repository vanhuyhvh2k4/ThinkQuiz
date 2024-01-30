using Mapster;
using ThinkQuiz.Application.Class.Commands.AddStudent;
using ThinkQuiz.Application.Class.Commands.JoinClass;
using ThinkQuiz.Contracts.Class.AddStudent;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Api.Common.Mapping.Class
{
    public class JoinClassMapping : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            // Add student to class
            config.NewConfig<AddStudentRequest, AddStudentCommand>()
                .Map(dest => dest, src => src);

            config.NewConfig<ClassStudent, AddStudentResponse>()
                .Map(dest => dest.Data, src => src)
                .Map(dest => dest.Data.CreatedAt, src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.UpdatedAt, src => src.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

            // join class
            config.NewConfig<(Guid studentId, Guid classId), JoinClassCommand>()
                .Map(dest => dest.StudentId, src => src.studentId)
                .Map(dest => dest.ClassId, src => src.classId);
        }
    }
}

