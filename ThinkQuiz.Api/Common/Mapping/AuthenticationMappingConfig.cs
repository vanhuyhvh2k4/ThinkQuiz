using Mapster;
using ThinkQuiz.Application.Authentication.Commands.Register;
using ThinkQuiz.Contracts.Authentication;

namespace ThinkQuiz.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
	{
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
        }
    }
}

