using BookStore.Repositories.Books;
using BookStore.Repositories.Authors;
using BookStore.Services.BooksService;
using BookStore.Services.Authors;
using System.Reflection;
using System.Text.Json.Serialization;
using BookStore;
using Microsoft.EntityFrameworkCore;
using BookStore.Helpers;
using System.Runtime;

{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();

    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
    builder.Services.AddDbContext<Context>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });


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
    app.UseMiddleware<ErrorHandler>();

    app.MapControllers();

    app.Run();
}