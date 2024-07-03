var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configuration =>
    {
        configuration.WithOrigins(builder.Configuration["allowedOrigins"]!).AllowAnyMethod().AllowAnyHeader();
    });

    options.AddPolicy("free", configuration =>
    {
        configuration.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}
);
app.UseCors();
app.MapGet("/", () => "Hello World!");

app.Run();
