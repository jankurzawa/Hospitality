var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecksUI().AddInMemoryStorage();
var app = builder.Build();

app.UseAuthorization();
app.MapHealthChecksUI();
app.MapControllers();

app.Run();