using ThinkQuiz.Api;
using ThinkQuiz.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication();
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

