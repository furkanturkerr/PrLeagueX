using PrLeagueX.BusinessLayer.Abstract;
using PrLeagueX.BusinessLayer.Concrete;
using PrLeagueX.BusinessLayer.Mapping;
using PrLeagueX.DataAccessLayer.Abstract;
using PrLeagueX.DataAccessLayer.Concrate;
using PrLeagueX.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddDbContext<PrLeagueXContext>();

builder.Services.AddScoped<IStandingService, StandingManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<IMatchDal, EfMatchDal>();
builder.Services.AddScoped<IMatchService, MatchManager>();
builder.Services.AddScoped<IMatchDal, EfMatchDal>();
builder.Services.AddScoped<ISeasonDal, EfSeasonDal>();
builder.Services.AddScoped<ISeasonService, SeasonManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();