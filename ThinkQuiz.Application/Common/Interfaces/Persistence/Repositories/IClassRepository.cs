﻿using System;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;
namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
	public interface IClassRepository
	{
		void Create(ClassAggregate newClass);

		List<ClassAggregate> GetClassesByTeacherId(Guid teacherId);

		ClassAggregate? GetClassById(Guid classId);
	}
}

