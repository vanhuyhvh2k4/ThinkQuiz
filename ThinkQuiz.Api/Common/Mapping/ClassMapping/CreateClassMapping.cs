﻿using Mapster;
using ThinkQuiz.Application.Classes.Commands.Create;
using ThinkQuiz.Contracts.Class.Create;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Api.Common.Mapping.ClassMapping
{
    public class CreateClassMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Create class
            config.NewConfig<(Guid teacherId, CreateClassRequest createClassRequest), CreateClassCommand>()
                .Map(dest => dest.teacherId, src => src.teacherId)
                .Map(dest => dest, src => src.createClassRequest);

            config.NewConfig<Class, CreateClassResponse>()
                .Map(dest => dest.Data, src => src);
        }
    }
}

