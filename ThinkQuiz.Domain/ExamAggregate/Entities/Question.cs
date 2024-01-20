﻿using System;
using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;

namespace ThinkQuiz.Domain.ExamAggregate.Entities
{
	public class Question : Entity<QuestionId>
	{
        public int Number { get; private set; }

        public string Title { get; private set; }

        public double Point { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        private Question(
            QuestionId id,
            int number,
            string title,
            double point) : base(id)
        {
            Number = number;
            Title = title;
            Point = point;
        }

        public static Question Create(
            int number,
            string title,
            double point)
        {
            return new(
                QuestionId.CreateUnique(),
                number,
                title,
                point);
        }

#pragma warning disable CS8618
        private Question() { }
#pragma warning restore CS8618
    }
}
