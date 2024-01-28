﻿using Mapster;
using ThinkQuiz.Application.Class.Commands.AddStudent;
using ThinkQuiz.Application.Class.Commands.Create;
using ThinkQuiz.Application.Class.Commands.JoinClass;
using ThinkQuiz.Application.Class.Common;
using ThinkQuiz.Application.Class.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.AddStudent;
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

            config.NewConfig<(GetClassesRequest request, Guid teacherId) , GetClassesQuery>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<List<ClassResult>, GetClassesResponse>()
                .Map(dest => dest.Data.Classes, src => src);

            config.NewConfig<AddStudentRequest, AddStudentCommand>();

            config.NewConfig<AddStudentResult, AddStudentResponse>()
                .Map(dest => dest.Data, src => src);

            config.NewConfig<(Guid studentId, Guid classId), JoinClassCommand>()
                .Map(dest => dest.StudentId, src => src.studentId)
                .Map(dest => dest.ClassId, src => src.classId);
        }
    }
}

