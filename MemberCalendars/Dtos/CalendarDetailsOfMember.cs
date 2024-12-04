using MemberCalendars.Models;
using System.ComponentModel.DataAnnotations;
namespace MemberCalendars.Dtos
{
    public class CalendarDetailsOfMember
    {
        //[Required] public Guid Mid { get; set; }
        //[Required] public string Mname { get; set; }
        //[Required] public string Mphone { get; set; }
        //// 此Member 所參與的Calendars
        //public List<Calendar> Calendars { get; set; } = new List<Calendar>();

        public Guid Mid { get; set; }
        public string Mname { get; set; } = string.Empty; // 初始化為空字串
        public string Mphone { get; set; } = string.Empty; // 初始化為空字串
        public List<Calendar> Calendars { get; set; } = new List<Calendar>(); // 初始化為空列表

    }
}
