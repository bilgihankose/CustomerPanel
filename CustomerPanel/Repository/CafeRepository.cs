using CustomerPanel.Context;
using CustomerPanel.Models;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPanel.Repository
{
    public class CafeRepository : ICafeRepository
    {
        private readonly CafeManagementContext _cafeManagementContext;

        public CafeRepository(CafeManagementContext cafeManagementContext)
        {
            _cafeManagementContext = cafeManagementContext;
        }
        public List<Cafe> GetCafes()
        {
            return _cafeManagementContext.Cafes.ToList();
    
        }
    }
}