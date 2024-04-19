namespace Movie_Application.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
