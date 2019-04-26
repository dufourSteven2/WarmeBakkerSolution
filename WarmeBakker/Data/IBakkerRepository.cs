using System.Collections.Generic;
using System.Linq;
using WarmeBakkerLib;

namespace WarmeBakker.Data
{
    public interface IBakkerRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<NewsMessages> GetNewsMessages();
    }
}