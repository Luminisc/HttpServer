using Snadbox.Core;
using Snadbox.Core.Infrastructure;

var builder = WebApplication.CreateBuilder(args); // IHostApplicationBuilder
builder.Services.AddScoped<IGoalsDb, GoalsDb>();
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/goal", (IGoalsDb goalsDb) => goalsDb.Get());                                       // IEndpointRouteBuilder.MapGet(this IEndpointRouteBuilder endpoints, string pattern, Delegate handler)
app.MapGet("/goal/{id}", (Guid id, IGoalsDb goalsDb) => goalsDb.Get(id));
app.MapPut("/goal", (Goal goal, IGoalsDb goalsDb) => goalsDb.Create(goal));
app.MapPost("/goal/{id}", (Guid id, Goal goal, IGoalsDb goalsDb) => goalsDb.Update(goal));
app.MapDelete("/goal/{id}", (Guid id, IGoalsDb goalsDb) => goalsDb.Delete(id));

app.Run();
