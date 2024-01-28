using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Class;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Application.Class.Commands.Create
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, ErrorOr<ClassAggregate>>
	{
        private readonly IClassRepository _classRepository;

        public CreateClassCommandHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<ClassAggregate>> Handle(CreateClassCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. check class name exists
            var classes = _classRepository.GetClassesByTeacherId(command.teacherId);

            foreach (var item in classes)
            {
                if (item.Name == command.Name.Trim())
                {
                    return Exceptions.DuplicateClass;
                }
            }
            // 2. create class

            var newClass = ClassAggregate.Create(command.teacherId, command.Name, command.SchoolYear);

            // 3. persist db
            _classRepository.Create(newClass);

            return newClass;
        }
    }
}

