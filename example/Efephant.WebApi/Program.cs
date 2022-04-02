using Efephant;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgres<Context>(builder.Configuration);

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(c => c.SingleLine = true);
builder.Logging.AddJsonStateConsole();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpIOLogging();
app.UseErrorBody(Error.Interpret);
app.MapControllers();

app.Migrate<Context>();
app.Run();

public partial class Program {}