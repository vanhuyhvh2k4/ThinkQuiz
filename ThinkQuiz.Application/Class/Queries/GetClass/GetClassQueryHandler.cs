using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Class;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Application.Class.Queries.GetClass
{
    public class GetClassQueryHandler : IRequestHandler<GetClassQuery, ErrorOr<ClassAggregate>>
	{
        private readonly IClassRepository _classRepository;

        public GetClassQueryHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<ClassAggregate>> Handle(GetClassQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_classRepository.GetClassById(query.ClassId) is not ClassAggregate classAggregate)
            {
                return Exceptions.NotFoundClass;
            }

            return classAggregate;
        }
    }
}

