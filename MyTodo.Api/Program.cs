using MyTodo.Api.Application.AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    var connectionString = configuration.GetConnectionString("DbConnection");

    option.UseSqlite(connectionString);
});

builder.Services.AddMediatR(typeof(Program));
//// Ìí¼Óautoampper
var automapperconfig = new MapperConfiguration(config =>
{
    config.AddProfile(new TodoProfile());
});
builder.Services.AddSingleton(automapperconfig.CreateMapper());

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IMemoRepository, MemoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();