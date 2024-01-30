using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Class;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Application.Classes.Queries.GetClass
{
    public class GetClassQueryHandler : IRequestHandler<GetClassQuery, ErrorOr<Class>>
	{
        private readonly IClassRepository _classRepository;

        public GetClassQueryHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<Class>> Handle(GetClassQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_classRepository.GetClassById(query.ClassId) is not Class classAggregate)
            {
                return Exceptions.NotFoundClass;
            }

            return classAggregate;
        }
    }
}

