using System;
namespace ThinkQuiz.Application.Common.Validator.DateTimeValidator
{
	public static partial class DateTimeValidators
	{
		public static bool BeLessThanCurrentDay(DateOnly date)
		{
			return date < DateOnly.FromDateTime(DateTime.Now);
		}
	}
}

