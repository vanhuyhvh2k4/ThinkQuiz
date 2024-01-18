using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;
using ThinkQuiz.Application.Common.Interfaces.Jwt;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.User;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
	{
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
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
            var user = User.Create(command.FullName, command.Email, command.Password);
            var token = _tokenGenerator.GenerateToken(user);

            // 3. persist user

            _userRepository.Add(user);

            return new AuthenticationResult(user, token); ;
        }
    }
}

