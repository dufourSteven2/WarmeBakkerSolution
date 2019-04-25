using System.Collections.Generic;
using WarmeBakkerLib;

namespace WarmeBakker.Data
{
    public interface IBakkerRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<NewsMessages> GetNewsMessages();
    }
}