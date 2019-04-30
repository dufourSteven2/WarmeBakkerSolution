using System.Collections.Generic;
using System.Linq;
using WarmeBakkerLib;

namespace WarmeBakker.Data
{
    public interface IBakkerRepository
    {
        //products
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        IEnumerable<topicsContactForm> Getcontacttopics();

        IEnumerable<NewsMessages> GetNewsMessages();
        
    }
}