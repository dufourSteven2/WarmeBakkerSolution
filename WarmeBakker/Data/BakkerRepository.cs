using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarmeBakkerLib;

namespace WarmeBakker.Data
{
    public class BakkerRepository : IBakkerRepository
    {
        private readonly WarmeBakkerContext _ctx;
        private readonly ILogger<BakkerRepository> _logger;

        public BakkerRepository(WarmeBakkerContext ctx, ILogger<BakkerRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products.OrderBy(p => p.Category).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<NewsMessages> GetNewsMessages()
        {
            try
            {
                _logger.LogInformation("Get News Messages that can show for this day");
                DateTime Today = DateTime.Today;
                return _ctx.NewsMessages.Where(nm => nm.StartDate >= Today && Today <= nm.EndDate).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get the news messages that can show this day: {ex}");
                return null;
            }
        }
    }
}
