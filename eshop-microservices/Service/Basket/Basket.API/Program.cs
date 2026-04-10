var builder = WebApplication.CreateBuilder(args);

// Add services to the cointanier

var app = builder.Build();

// Configure the GTTP request pipeline.

app.Run();
