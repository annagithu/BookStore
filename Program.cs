using BookStore.Repositories.Books;
using BookStore.Repositories.Authors;
using BookStore.Services.BooksService;
using BookStore.Services.Authors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using BookStore;
using Microsoft.EntityFrameworkCore;

{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();

    //Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
    //builder.Services.AddSerilog();
    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    builder.Services.AddControllers();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    builder.Services.AddDbContext<Context>(
        options => options.UseNpgsql(@"host=localhost;port=5432;database=bookstore;username=postgres;password=1234"));
    builder.Services.AddScoped<IBooksRepository, BooksRepository>();
    builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
    builder.Services.AddScoped<IBooksService, BooksService>();
    builder.Services.AddScoped<IAuthorsService, AuthorsService>();
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    var app = builder.Build();



    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseAuthorization();


    app.MapControllers();

    app.Run();
}