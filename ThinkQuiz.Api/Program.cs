using ThinkQuiz.Api;
using ThinkQuiz.Application;
using ThinkQuiz.Infrashstructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrashstructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseAuthentication();

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

