using Mapster;
using ThinkQuiz.Application.Authentication.Commands.Login;
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

            config.NewConfig<LoginRequest, LoginCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Data, src => src.User)
                .Map(dest => dest.Data.CreatedAt, src => src.User.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.UpdatedAt, src => src.User.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.LastLogin, src => src.User.LastLogin.ToString("yyyy-MM-dd HH:mm:ss"))
                .Map(dest => dest.Data.Token, src => src.Token)
                .Map(dest => dest.Data.Id, src => src.User.Id.ToString());
        }
    }
}

