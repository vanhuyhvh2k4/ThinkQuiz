using System;
using FluentValidation;

namespace ThinkQuiz.Application.Class.Commands.AddStudent
{
	public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
	{
		public AddStudentCommandValidator()
		{
		}
	}
}

