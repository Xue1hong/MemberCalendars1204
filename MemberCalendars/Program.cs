using MemberCalendars.Contracts;
using MemberCalendars.Repositories;
using MemberCalendars.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbContext>();

// 將MemberRepository 類型的實例注入到IMember 容器中
builder.Services.AddScoped<MemberCalendars.Contracts.IMember, MemberRepository>();
// 將CalendarRepository 類型的實例注入到ICalendar 容器中
builder.Services.AddScoped<MemberCalendars.Contracts.ICalendar, CalendarRepository>();
// 將CrossRepository 類型的實例注入到ICross 容器中
builder.Services.AddScoped<ICross, CrossRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
