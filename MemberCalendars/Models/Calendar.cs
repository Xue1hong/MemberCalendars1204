
namespace MemberCalendars.Models
{
    public class Calendar
    {
        public int Cid { get; set; }
        public string Cname { get; set; } = string.Empty;
        public int Cpriority { get; set; }
        public bool Cfinish { get; set; }
        public string? Cmemo { get; set; }
    }
}
