using Bookstore.Help.Errors;
using Bookstore.Help.Extensions;
using Bookstore.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();
builder.Services.AddDbContext<BookstoreContext>(opt =>
{
    opt.UseInMemoryDatabase("BookstoreDb");
    opt.EnableSensitiveDataLogging();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(origin => true));
}

app.UseHttpsRedirection();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseAuthorization();

app.MapControllers();

app.Run();
