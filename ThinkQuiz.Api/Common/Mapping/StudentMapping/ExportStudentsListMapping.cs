using System;
using Mapster;
using ThinkQuiz.Application.Students.Queries.ExportStudentsList;

namespace ThinkQuiz.Api.Common.Mapping.StudentMapping
{
	public class ExportStudentsListMapping : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Guid teacherId, Guid classId), ExportStudentsListQuery>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest.ClassId, src => src.classId);
        }
    }
}

