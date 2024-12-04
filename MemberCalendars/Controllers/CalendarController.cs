using MemberCalendars.Contracts;
using MemberCalendars.Dtos;
using MemberCalendars.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemberCalendars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendar _calendarRepository;

        public CalendarController(ICalendar calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        /// <summary>
        /// 查詢所有行事曆資料
        /// </summary>
        /// <returns>所有行事曆的資料</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCalendars()
        {
            var calendars = await _calendarRepository.GetAllCalendars();
            return Ok(new
            {
                Success = true,
                Message = "成功取得所有行事曆資料",
                Data = calendars
            });
        }

        /// <summary>
        /// 查詢指定 ID 的行事曆資料
        /// </summary>
        /// <param name="id">行事曆的唯一識別碼</param>
        /// <returns>指定行事曆的資料</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendarById(int id)
        {
            var calendar = await _calendarRepository.GetCalendarById(id);
            if (calendar == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的行事曆資料"
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "成功取得指定行事曆資料",
                Data = calendar
            });
        }

        /// <summary>
        /// 新增行事曆資料
        /// </summary>
        /// <param name="calendar">新增的行事曆資料</param>
        /// <returns>新增後的行事曆資料</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCalendar(CalendarForCreationDto calendar)
        {
            var createdCalendar = await _calendarRepository.CreateCalendar(calendar);
            return CreatedAtAction(nameof(GetCalendarById), new { id = createdCalendar }, new
            {
                Success = true,
                Message = "成功新增行事曆資料",
                Data = createdCalendar
            });
        }

        /// <summary>
        /// 更新指定 ID 的行事曆資料
        /// </summary>
        /// <param name="id">行事曆的唯一識別碼</param>
        /// <param name="calendar">更新的行事曆資料</param>
        /// <returns>更新結果</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalendar(int id, CalendarForUpdateDto calendar)
        {
            var existingCalendar = await _calendarRepository.GetCalendarById(id);
            if (existingCalendar == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的行事曆資料"
                });
            }

            await _calendarRepository.UpdateCalendar(id, calendar);
            return Ok(new
            {
                Success = true,
                Message = "成功更新行事曆資料"
            });
        }

        /// <summary>
        /// 刪除指定 ID 的行事曆資料
        /// </summary>
        /// <param name="id">行事曆的唯一識別碼</param>
        /// <returns>刪除結果</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
        {
            var existingCalendar = await _calendarRepository.GetCalendarById(id);
            if (existingCalendar == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "找不到指定的行事曆資料"
                });
            }

            await _calendarRepository.DeleteCalendar(id);
            return Ok(new
            {
                Success = true,
                Message = "成功刪除行事曆資料"
            });
        }
    }
}
