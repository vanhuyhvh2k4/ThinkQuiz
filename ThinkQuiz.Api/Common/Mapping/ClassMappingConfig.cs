﻿using Mapster;
using ThinkQuiz.Application.Class.Commands.AddStudent;
using ThinkQuiz.Application.Class.Commands.Create;
using ThinkQuiz.Application.Class.Commands.JoinClass;
using ThinkQuiz.Application.Class.Common;
using ThinkQuiz.Application.Class.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.AddStudent;
using ThinkQuiz.Contracts.Class.Create;
using ThinkQuiz.Contracts.Class.GetClass;
using ThinkQuiz.Contracts.Class.GetClasses;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Api.Common.Mapping
{
    public class ClassMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Create class
            config.NewConfig<(Guid teacherId, CreateClassRequest createClassRequest), CreateClassCommand>()
                .Map(dest => dest.teacherId, src => src.teacherId)
                .Map(dest => dest, src => src.createClassRequest);

            config.NewConfig<Class, CreateClassResponse>()
                .Map(dest => dest.Data, src => src)
                .Map(dest => dest.Data.CreatedAt, src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.UpdatedAt, src => src.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));


            // Get classes
            config.NewConfig<(GetClassesRequest request, Guid teacherId) , GetClassesQuery>()
                .Map(dest => dest.TeacherId, src => src.teacherId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<List<ClassResult>, GetClassesResponse>()
                .Map(dest => dest.Data.Classes, src => src);

            // Get class by id
            config.NewConfig<Class, GetClassResponse>()
                .Map(dest => dest.Class, src => src)
                .Map(dest => dest.Class.CreatedAt, src => src.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Class.UpdatedAt, src => src.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Class.Teacher.Id, src => src.Teacher.Id)
                .Map(dest => dest.Class.Teacher.Name, src => src.Teacher.User.FullName)
                .Map(dest => dest.Class.Teacher.Email, src => src.Teacher.User.Email)
                .Map(dest => dest.Class.Teacher.Phone, src => src.Teacher.User.Phone)
                .Map(dest => dest.Class.Teacher.Position, src => src.Teacher.Position)
                .Map(dest => dest.Class.Teacher.SchoolInformation, src => src.Teacher.SchoolInformation);

            // Add student to class
            config.NewConfig<AddStudentRequest, AddStudentCommand>();

            config.NewConfig<AddStudentResult, AddStudentResponse>()
                .Map(dest => dest.Data, src => src);

            // join class
            config.NewConfig<(Guid studentId, Guid classId), JoinClassCommand>()
                .Map(dest => dest.StudentId, src => src.studentId)
                .Map(dest => dest.ClassId, src => src.classId);
        }
    }
}

