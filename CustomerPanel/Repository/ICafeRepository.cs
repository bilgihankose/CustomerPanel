using CustomerPanel.Models;
using System.Collections.Generic;

namespace CustomerPanel.Repository
{
    public interface ICafeRepository 
    {
        List<Cafe> GetCafes();
    }
}
