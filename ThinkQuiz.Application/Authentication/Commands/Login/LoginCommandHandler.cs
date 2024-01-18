using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;
using ThinkQuiz.Application.Common.Interfaces.Jwt;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Authentication;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
	{
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Check user exists
            if (_userRepository.GetUserByEmail(command.Email) is not User user)
            {
                return Exceptions.InvalidCredentials;
            }
            // 2. Check credentials
            if (user.Password != command.Password)
            {
                return Exceptions.InvalidCredentials;
            }

            // 3. Persist db and create token
            var token = _jwtTokenGenerator.GenerateToken(user);

            user.UpdateLastLogin();

            return new AuthenticationResult(user, token);
        }
    }
}

