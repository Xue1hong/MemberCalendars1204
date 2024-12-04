using MemberCalendars.Dtos;
using MemberCalendars.Models;

namespace MemberCalendars.Contracts
{
    public interface ICalendar
    {
        /// <summary>
        /// 查詢所有 Calendar 資料
        /// </summary>
        /// <returns>所有行事曆的資料集合</returns>
        Task<IEnumerable<Calendar>> GetAllCalendars();

        /// <summary>
        /// 查詢單一 Calendar 資料（依指定 id）
        /// </summary>
        /// <param name="id">行事曆的唯一識別碼</param>
        /// <returns>指定行事曆的資料</returns>
        Task<Calendar> GetCalendarById(int id);

        /// <summary>
        /// 新增 Calendar 資料
        /// </summary>
        /// <param name="calendar">新增的行事曆資料</param>
        /// <returns>新增行事曆的資料</returns>
        Task<CalendarForCreationDto> CreateCalendar(CalendarForCreationDto calendar);

        /// <summary>
        /// 更新 Calendar 資料（依指定 id）
        /// </summary>
        /// <param name="id">行事曆的唯一識別碼</param>
        /// <param name="calendar">更新的行事曆資料</param>
        /// <returns>Task</returns>
        Task UpdateCalendar(int id, CalendarForUpdateDto calendar);

        /// <summary>
        /// 刪除 Calendar 資料（依指定 id）
        /// </summary>
        /// <param name="id">行事曆的唯一識別碼</param>
        /// <returns>Task</returns>
        Task DeleteCalendar(int id);
    }
}
