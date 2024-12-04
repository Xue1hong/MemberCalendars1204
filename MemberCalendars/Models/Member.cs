namespace MemberCalendars.Models
{
    public class Member
    {
        public Guid Mid { get; set; }
        public string Mname { get; set; } = string.Empty;
        public int Mage { get; set; }
        public string? Maddress { get; set; }
        public string? Mphone { get; set; }
    }
}
