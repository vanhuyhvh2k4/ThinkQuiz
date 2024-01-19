using Mapster;
using ThinkQuiz.Application.Users.Commands;
using ThinkQuiz.Contracts.Users;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(UpdateUserRequest Request, Guid UserId), UpdateUserCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<User, UpdateUserResponse>()
                .Map(dest => dest.Data.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.Data, src => src);
        }
    }
}

