using NotificationPattern.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatServices();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePages();
app.UseExceptionHandler();
app.UseCreateCat();

app.Run();
