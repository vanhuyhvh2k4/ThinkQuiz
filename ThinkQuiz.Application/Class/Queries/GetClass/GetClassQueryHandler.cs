using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Class.Common;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Class;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Application.Class.Queries.GetClass
{
    public class GetClassQueryHandler : IRequestHandler<GetClassQuery, ErrorOr<ClassResult>>
	{
        private readonly IClassRepository _classRepository;

        public GetClassQueryHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<ClassResult>> Handle(GetClassQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_classRepository.GetClassById(query.ClassId) is not ClassAggregate classAggregate)
            {
                return Exceptions.NotFoundClass;
            }

            var classResult = new ClassResult(classAggregate.Id.ToString(),
                                              classAggregate.TeacherId.ToString(),
                                              classAggregate.Name,
                                              classAggregate.SchoolYear,
                                              classAggregate.StudentQuantity,
                                              classAggregate.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                                              classAggregate.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

            return classResult;
        }
    }
}

