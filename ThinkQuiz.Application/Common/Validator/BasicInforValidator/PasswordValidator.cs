using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ThinkQuiz.Application.Common.Validator.BasicInforValidator
{
	public static partial class BasicInforValidators
	{
		public static bool BePassword(string password)
		{
            string regexPattern = "^(?=.*[a-zA-Z])(?=.*\\d)(?=.*[^\\w\\s]).+$";

            bool isMatch = Regex.IsMatch(password, regexPattern);
            return isMatch;
        }
	}
}

