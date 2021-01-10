using CustomerPanel.Models;
using System.Collections.Generic;

namespace CustomerPanel.ViewModels
{
    public class CustomerViewModel
    {
        public long Tc { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Year { get; set; }
        public int CafeId { get; set; }
        public List<Cafe> cafes { get; set; }
    }
}