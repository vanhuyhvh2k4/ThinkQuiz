using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.User;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
	{
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Check user exists
            if (_userRepository.GetUserById(command.UserId) is not User user)
            {
                return Exceptions.NotFoundUser;
            }
            // 2. Update user
            user.Update(
                fullName: command.FullName,
                gender: command.Gender,
                dateOfBirth: command.DateOfBirth,
                phone: command.Phone);

            _userRepository.UpdateUser(user);
            // 3. Persist db
            return user;
        }
    }
}

