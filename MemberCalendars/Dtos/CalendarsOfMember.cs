using System.ComponentModel.DataAnnotations;
namespace MemberCalendars.Dtos
{
    public class CalendarsOfMember 
    {
        [Required] 
        public Guid Mid { get; set; }
        [Required] 
        public string Mname { get; set; }
        [Required] 
        public string Mphone { get; set; }
        // 此Member 所參與的Calendars
        public List<String> Calendars{ get; set; } = new List<String>();}
}
