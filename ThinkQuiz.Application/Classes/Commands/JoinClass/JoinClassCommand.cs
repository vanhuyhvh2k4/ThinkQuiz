﻿using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Application.Classes.Commands.JoinClass
{
    public record JoinClassCommand(Guid StudentId, Guid ClassId) : IRequest<ErrorOr<ClassStudent>>;
}

