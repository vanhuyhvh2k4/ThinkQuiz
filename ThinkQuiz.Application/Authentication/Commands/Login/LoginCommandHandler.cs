using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Application.Common.Interfaces.Services.Bcrypt;
using ThinkQuiz.Application.Common.Interfaces.Services.Jwt;
using ThinkQuiz.Domain.Common.Exceptions.Authentication;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
	{
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IBcryptHashPassword _hashPassword;

        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IBcryptHashPassword hashPassword)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _hashPassword = hashPassword;
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
            if (!_hashPassword.VerifyPassword(command.Password, user.Password))
            {
                return Exceptions.InvalidCredentials;
            }

            // 3. Persist db and create token
            var token = _jwtTokenGenerator.GenerateToken(user);

            user.UpdateLastLogin();

            _userRepository.UpdateUser(user);

            return new AuthenticationResult(user, token);
        }
    }
}

