//using MemberCalendars.Contracts;
//using MemberCalendars.Utilities;
//using MemberCalendars.Dtos;
//using Dapper;
//using MemberCalendars.Models;
//using Microsoft.AspNetCore.Mvc;
//namespace MemberCalendars.Repositories
//{
//    public class CrossRepository : ICross
//    {
//        private readonly DbContext _dbContext; 
//        public CrossRepository(DbContext dbContext) 
//        {
//            _dbContext = dbContext; 
//        }
//        // 查詢Member 和他/她參與的所有Calendars 資料（依指定id）
//        public async Task<CalendarsOfMember> GetCalendarsByMemberId(Guid id)
//        {
//            string sqlQuery = "SELECT Mid, Mname, Mphone FROM Member WHERE Mid = @Id;" +
//                "SELECT C.Cname FROM Calendar C, CalendarJoin J " +
//                "WHERE J.Mid = @Id AND C.Cid = J.Cid;";
//            using (var connection = _dbContext.CreateConnection())
//            {
//                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
//                var member = await multi.ReadSingleOrDefaultAsync<CalendarsOfMember>();
//                if (member != null)
//                    member.Calendars= (await multi.ReadAsync<String>()).ToList();
//                return member;
//            }            
//        }// 查詢Calendar 和參與的所有Member 資料（依指定id）
//        public async Task<MembersOfCalendar> GetMembersByCalendarId(int id)
//        {
//            string sqlQuery = "SELECT Cid, Cname FROM Calendar WHERE Cid = @Id;" + 
//                "SELECT M.Mname FROM Member M, CalendarJoin J " + 
//                "WHERE J.Cid = @Id AND M.Mid = J.Mid;";
//            using (var connection = _dbContext.CreateConnection())
//            {
//                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id }); 
//                var calendar = await multi.ReadSingleOrDefaultAsync<MembersOfCalendar>();
//                if (calendar != null)
//                    calendar.Members= (await multi.ReadAsync<String>()).ToList();
//                return calendar;
//            }
//        }

//        [HttpGet("CalendarDetailsForMember/{id}")]
//        public async Task<IActionResult> GetCalendarDetailsByMemberId(Guid id)
//        {
//            try
//            {
//                // 取得指定id 的會員資料
//                var calendarDetails = await _cross.GetCalendarDetailsByMemberId(id);
//                return Ok(new
//                {
//                    Success = true,
//                    Message = "取得指定id 會員的所有行事曆詳細資料成功",
//                    Data = calendarDetails
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);}}

//        // 查詢Member 和他/她參與的所有Calendars 的詳細資料（依指定id）
//        public async Task<CalendarDetailsOfMember> GetCalendarDetailsByMemberId(Guid id)
//        {
//              string sqlQuery = "SELECT Mid, Mname, Mphone FROM Member WHERE Mid = @Id;" +
//                  "SELECT C.* FROM Calendar C, CalendarJoin J " +
//                  "WHERE J.Mid = @Id AND C.Cid = J.Cid;";
//              using (var connection = _dbContext.CreateConnection())
//              {
//                  var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
//                  var member = await multi.ReadSingleOrDefaultAsync<CalendarDetailsOfMember>();
//                  if (member !=null)
//                      member.Calendars = (await multi.ReadAsync<Calendar>()).ToList();
//                  return member;
//              }
//        }
//        [HttpGet("MemberDetailsForCalendar/{id}")]
//        public async Task<IActionResult> GetMemberDetailsByCalendarId(int id)
//        {
//            try
//            {
//                // 取得指定id 的行事曆資料
//                var memberDetails = await _cross.GetMemberDetailsByCalendarId(id);
//                return Ok(new
//                {
//                    Success = true,
//                    Message = "取得指定id 行事曆的所有會員詳細資料成功",
//                    Data = memberDetails
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        public async Task<MemberDetailsOfCalendar> GetMemberDetailsByCalendarId(int id) 
//        { 
//            string sqlQuery = "SELECT Cid, Cname FROM Calendar WHERE Cid = @Id;" + 
//                "SELECT M.* FROM Member M, CalendarJoin J " + 
//                "WHERE J.Cid = @Id AND M.Mid = J.Mid;"; 
//            using (var connection = _dbContext.CreateConnection()) 
//            { 
//                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
//                var calendar = await multi.ReadSingleOrDefaultAsync<MemberDetailsOfCalendar>(); 
//                if (calendar != null) 
//                    calendar.Members = (await multi.ReadAsync<Member>()).ToList(); 
//                return calendar; 
//            } 
//        }
//    }
//}

using MemberCalendars.Contracts;
using MemberCalendars.Utilities;
using MemberCalendars.Dtos;
using Dapper;
namespace MemberCalendars.Repositories
{
    public class CrossRepository : ICross
    {
        private readonly DbContext _dbContext; 
        public CrossRepository(DbContext dbContext) { _dbContext = dbContext; }

        public Task<CalendarDetailsOfMember> GetCalendarDetailsByMemberId(Guid id)
        {
            throw new NotImplementedException();
        }

        // 查詢Member 和他/她參與的所有Calendars 資料（依指定id）
        public async Task<CalendarsOfMember> GetCalendarsByMemberId(Guid id)
        {
            string sqlQuery = "SELECT Mid, Mname, Mphone FROM Member WHERE Mid = @Id;" +
                "SELECT C.Cname FROM Calendar C, CalendarJoin J " +
                "WHERE J.Mid = @Id AND C.Cid = J.Cid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var member = await multi.ReadSingleOrDefaultAsync<CalendarsOfMember>();
                if (member != null)
                    member.Calendars= (await multi.ReadAsync<String>()).ToList();
                return member;}            }

        public Task<MemberDetailsOfCalendar> GetMemberDetailsByCalendarId(int id)
        {
            throw new NotImplementedException();
        }

        // 查詢Calendar 和參與的所有Member 資料（依指定id）
        public async Task<MembersOfCalendar> GetMembersByCalendarId(int id){
            string sqlQuery = "SELECT Cid, Cname FROM Calendar WHERE Cid = @Id;" + 
                "SELECT M.Mname FROM Member M, CalendarJoin J " + 
                "WHERE J.Cid = @Id AND M.Mid = J.Mid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id }); 
                var calendar = await multi.ReadSingleOrDefaultAsync<MembersOfCalendar>();
                if (calendar != null)calendar.Members= (await multi.ReadAsync<String>()).ToList();
                return calendar;
            }
        }
    }
}
