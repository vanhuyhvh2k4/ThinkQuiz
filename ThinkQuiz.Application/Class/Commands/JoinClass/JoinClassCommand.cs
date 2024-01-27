using System;
using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Class.Common;

namespace ThinkQuiz.Application.Class.Commands.JoinClass
{
	public record JoinClassCommand(Guid StudentId, Guid ClassId) : IRequest<ErrorOr<AddStudentResult>>;
}

