using PlanY.Presentation.Apis.DailyPlanApi;
using PlanY.Presentation.Apis.UserApi;
using PlanY.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPresentationLayer(builder.Configuration);

var app = builder.Build();

app.MapDailyPlanV1();
app.MapUserApiV1();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();