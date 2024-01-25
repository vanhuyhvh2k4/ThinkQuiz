using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Application.Common.Interfaces.Services.Bcrypt;
using ThinkQuiz.Application.Common.Interfaces.Services.Jwt;
using ThinkQuiz.Domain.Common.Exceptions.User;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
	{
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IBcryptHashPassword _hashPassword;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator,
            IBcryptHashPassword hashPassword,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _hashPassword = hashPassword;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
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
            object? registerEntity = null;

            // 4. persist user

            _userRepository.Add(user);

            if (command.RegisterType.Equals(RegisterType.Student))
            {
                var student = Student.Create(user.Id);
                registerEntity = student;
                _studentRepository.Add(student);

            }

            if (command.RegisterType.Equals(RegisterType.Teacher))
            {
                var teacher = Teacher.Create(user.Id, command.Position!, command.SchoolInformation!);
                registerEntity = teacher;
                _teacherRepository.Add(teacher);
            }

            var token = _tokenGenerator.GenerateToken(user, teacher: registerEntity as Teacher ?? null, student: registerEntity as Student ?? null);

            return new AuthenticationResult(
                user,
                command.RegisterType.Equals(RegisterType.Teacher) ? true : false,
                token); ;
        }
    }
}

