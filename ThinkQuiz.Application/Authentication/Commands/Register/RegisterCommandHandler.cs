using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Application.Common.Interfaces.Services.Bcrypt;
using ThinkQuiz.Application.Common.Interfaces.Services.Jwt;
using ThinkQuiz.Domain.Common.Exceptions.User;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
	{
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IBcryptHashPassword _hashPassword;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator, IBcryptHashPassword hashPassword)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _hashPassword = hashPassword;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. validate if user exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Exceptions.DuplicateEmailsException;
            }

            // 2. create new user
            var user = User.Create(command.FullName, command.Email, _hashPassword.HashPassword(command.Password));
            var token = _tokenGenerator.GenerateToken(user);

            // 3. persist user

            _userRepository.Add(user);

            return new AuthenticationResult(user, token); ;
        }
    }
}

