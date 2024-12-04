using MemberCalendars.Dtos;
namespace MemberCalendars.Contracts
{
    public interface ICross
    {
        // 查詢Member 和他/她參與的所有Calendars 資料（依指定id）
        public Task<CalendarsOfMember> GetCalendarsByMemberId(Guid id);
        // 查詢Calendar 和參與其中的所有Members 資料（依指定id）
        public Task<MembersOfCalendar> GetMembersByCalendarId(int id);

        // 查詢Member 和他/她參與的所有Calendars 的詳細資料（依指定id）
        public Task<CalendarDetailsOfMember> GetCalendarDetailsByMemberId(Guid id);
        //// 查詢Calendar 和參與其中的所有Members 的詳細資料（依指定id）
        public Task<MemberDetailsOfCalendar> GetMemberDetailsByCalendarId(int id);
    }
}
