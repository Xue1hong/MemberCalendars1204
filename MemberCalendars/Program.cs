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

// �NMemberRepository ��������Ҫ`�J��IMember �e����
builder.Services.AddScoped<MemberCalendars.Contracts.IMember, MemberRepository>();
// �NCalendarRepository ��������Ҫ`�J��ICalendar �e����
builder.Services.AddScoped<MemberCalendars.Contracts.ICalendar, CalendarRepository>();
// �NCrossRepository ��������Ҫ`�J��ICross �e����
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