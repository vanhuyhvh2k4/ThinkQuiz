using System.Text.RegularExpressions;

namespace ThinkQuiz.Application.Common.Validator.BasicInforValidator
{
	public static partial class BasicInforValidators
    {
		public static bool BePhone(string phone)
		{
            string regexPattern = @"^\d{10}$"; // Regex pattern for a 10-digit phone number

            bool isMatch = Regex.IsMatch(phone, regexPattern);
            return isMatch;
        }
	}
}

