using MemberCalendars.Models;
using System.ComponentModel.DataAnnotations;
namespace MemberCalendars.Dtos
{
    public class MemberDetailsOfCalendar
    {
        [Required] public int Cid { get; set; }
        [Required] public string Cname { get; set; }
        // 參與此Calendar 的成員
        public List<Member> Members { get; set; } = new List<Member>();}
    }
