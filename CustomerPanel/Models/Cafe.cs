using System.Collections.Generic;

namespace CustomerPanel.Models
{
    public class Cafe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Customer> customers { get; set; }
    }
}