using Mapster;
using ThinkQuiz.Application.Authentication.Commands.Register;
using ThinkQuiz.Application.Authentication.Common;
using ThinkQuiz.Contracts.Authentication;

namespace ThinkQuiz.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => src.User.Id.Value.ToString());
        }
    }
}

