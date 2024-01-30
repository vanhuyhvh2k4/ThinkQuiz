using Mapster;
using ThinkQuiz.Application.Classes.Commands.AddStudent;
using ThinkQuiz.Application.Classes.Commands.JoinClass;
using ThinkQuiz.Contracts.Class.AddStudent;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Api.Common.Mapping.ClassMapping
{
    public class JoinClassMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Add student to class
            config.NewConfig<(Guid teacherId, AddStudentRequest request), AddStudentCommand>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<ClassStudent, AddStudentResponse>()
                .Map(dest => dest.Data, src => src);

            // join class
            config.NewConfig<(Guid studentId, Guid classId), JoinClassCommand>()
                .Map(dest => dest.StudentId, src => src.studentId)
                .Map(dest => dest.ClassId, src => src.classId);
        }
    }
}

