﻿using System;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Authentication.Common
{
	public record AuthenticationResult(
        User User,
        bool IsTeacher,
        string Token);
}

