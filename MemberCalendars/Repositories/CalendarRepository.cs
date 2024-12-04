using Dapper;
using MemberCalendars.Contracts;
using MemberCalendars.Dtos;
using MemberCalendars.Models;
using MemberCalendars.Utilities;
using System.Data;

namespace MemberCalendars.Repositories
{
    public class CalendarRepository : ICalendar
    {
        private readonly DbContext _dbContext;

        public CalendarRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Calendar>> GetAllCalendars()
        {
            const string query = "SELECT * FROM Calendar";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<Calendar>(query);
            }
        }

        public async Task<Calendar> GetCalendarById(int id)
        {
            const string query = "SELECT * FROM Calendar WHERE Cid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Calendar>(query, new { Id = id });
            }
        }

        public async Task<CalendarForCreationDto> CreateCalendar(CalendarForCreationDto calendar)
        {
            const string query = "INSERT INTO Calendar (Cname, Cpriority) OUTPUT INSERTED.* VALUES (@Cname, @Cpriority)";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleAsync<CalendarForCreationDto>(query, calendar);
            }
        }

        public async Task UpdateCalendar(int id, CalendarForUpdateDto calendar)
        {
            const string query = "UPDATE Calendar SET Cpriority = @Cpriority, Cfinish = @Cfinish, Cmemo = @Cmemo WHERE Cid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { calendar.Cpriority, calendar.Cfinish, calendar.Cmemo, Id = id });
            }
        }

        public async Task DeleteCalendar(int id)
        {
            const string query = "DELETE FROM Calendar WHERE Cid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
