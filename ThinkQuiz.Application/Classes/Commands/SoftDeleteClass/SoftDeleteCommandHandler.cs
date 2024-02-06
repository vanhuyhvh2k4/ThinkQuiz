using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassAggregate;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;

namespace ThinkQuiz.Application.Classes.Commands.SoftDeleteClass
{
    public class SoftDeleteCommandHandler : IRequestHandler<SoftDeleteClassCommand, ErrorOr<Class>>
	{
        private readonly IClassRepository _classRepository;

        public SoftDeleteCommandHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<Class>> Handle(SoftDeleteClassCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // check class exists and not remove
            if (_classRepository.GetClassById(command.ClassId) is not Class @class || @class.IsDeleted == true)
            {
                return ClassExceptions.NotFoundClass;
            }
            // check teacher owns class

            if (@class.TeacherId != command.TeacherId)
            {
                return ClassExceptions.NotOwnsClass;
            }

            // soft delete

            @class.ChangeIsDeleted(true);

            // persist db
            _classRepository.Update(@class);

            return @class;
        }
    }
}

