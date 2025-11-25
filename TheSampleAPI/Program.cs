using TheSampleAPI.Endpoints;
using TheSampleAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();
app.ApplyCorsConfig();
app.MapAllHealthChecks();
app.AddRootEndpoints();
app.AddErrorEndpoints();

app.AddCourseEndpoints();

app.UseAuthorization();

app.MapControllers();

app.Run();
