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
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IBcryptHashPassword _hashPassword;

        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IBcryptHashPassword hashPassword, ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _hashPassword = hashPassword;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
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

            string token = "";

            // check current role
            if (user.CurrentRole == true)
            {
                var teacher = _teacherRepository.GetTeacherByUserId(user.Id);
                token = _jwtTokenGenerator.GenerateToken(user, teacher, null);
            }

            if (user.CurrentRole == false)
            {
                var student = _studentRepository.GetStudentByUserId(user.Id);
                token = _jwtTokenGenerator.GenerateToken(user, null, student);
            }

            user.UpdateLastLogin();

            _userRepository.UpdateUser(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}

