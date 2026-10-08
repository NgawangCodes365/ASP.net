using CRUD_APP1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//what this line does is it creates Application builder.

builder.Services.AddControllers();
//this tells asp.net that this app will use controller

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PrimaryConnection")
    ));

    //builder.Services.AddDbContext means lets register AppDbContext so that my app can use it.
    //options.UseSqlServer means when AppDbContext comms with DB: USE SqlServer.
    //the final line builder.config..... means go to the configuration file .i.e. appsettings.json and find
    //Connection string named DefaultConnection.

builder.Services.AddOpenApi();
//this enables OpenAPI support so that we can describe/test our API.

var app = builder.Build();
//so the configuration we created through builder = turns into a web application.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
