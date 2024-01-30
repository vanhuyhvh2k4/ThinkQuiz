using Mapster;
using ThinkQuiz.Application.Students.Queries.GetStudentsOfClass;
using ThinkQuiz.Contracts.Students.Common;
using ThinkQuiz.Contracts.Students.GetStudentsOfClass;
using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Api.Common.Mapping.StudentMapping
{
    public class GetStudentMapping : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Student, StudentResponse>()
                .Map(dest => dest.FullName, src => src.User.FullName)
                .Map(dest => dest.Email, src => src.User.Email)
                .Map(dest => dest.Phone, src => src.User.Phone)
                .Map(dest => dest.Gender, src => src.User.Gender)
                .Map(dest => dest.DateOfBirth, src => src.User.DateOfBirth)
                .Map(dest => dest.LastLogin, src => src.User.LastLogin.ToString("yyyy-MM-dd HH:mm:ss"));

            config.NewConfig<(Guid teacherId, Guid classId, GetStudentsOfClassRequest request), GetStudentsOfClassQuery>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest.ClassId, src => src.classId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<List<Student>, GetStudentsOfClassResponse>()
                .Map(dest => dest.Data.Students, src => src);
        }
    }
}

