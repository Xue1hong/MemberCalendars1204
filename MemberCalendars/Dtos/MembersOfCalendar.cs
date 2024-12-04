using System.ComponentModel.DataAnnotations;
namespace MemberCalendars.Dtos
{
    public class MembersOfCalendar 
    { 
        [Required] 
        public int Cid { get; set; }
        [Required] 
        public string Cname { get; set; }
        // 參與此Calendar 的成員
        public List<String> Members{ get; set; } = new List<String>();
    }
}
