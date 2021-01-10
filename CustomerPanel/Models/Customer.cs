namespace CustomerPanel.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public long Tc { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int  Year { get; set; }
        public int CafeId { get; set; }
    }
}