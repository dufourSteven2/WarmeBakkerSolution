using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarmeBakkerLib;

namespace WarmeBakker.Data
{
    public class BakkerijSeeding

    {
        private readonly WarmeBakkerContext _ctx;
        public BakkerijSeeding(WarmeBakkerContext ctx)
        {
            _ctx = ctx;
        }

        public void seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                //Create Data
                var headCategories = new Category[]
           {
                new Category{Name="Brood", Description="alle soorten brood", Publication = true},
                new Category{Name="Taarten", Description="alle soorten taarten", Publication = true},
                 new Category{Name="Boterkoeken", Description="alle soorten boterkoeken", Publication = false}
           };
                foreach (Category c in headCategories)
                {
                    _ctx.Categories.Add(c);
                }
                _ctx.SaveChanges();

                var categories = new Category[]
                {
            new Category{ Name="Wit Brood", Description = "Alle Wit brood word op steen gebakken", HeadCategoryId = 1},
            new Category{ Name="Chocolade taart", Description = "Alle taarten met chocolade", HeadCategoryId = 2},
            new Category{ Name="Vetbommen", Description = "Alle brood word op steen gebakken", HeadCategoryId = 3}

                };
                foreach (Category c in categories)
                {
                    _ctx.Categories.Add(c);
                }
                _ctx.SaveChanges();



                var products = new Product[]
                {
            new Product{ Name = "klein wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken",  CategoryId = 4, Highlight=false},
            new Product{ Name = "Met slagroom" , Price = 2.25m, Description = "Een caloriebom", CategoryId = 6, Highlight=false},
            new Product{ Name = "Hoorntje" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 5, Highlight=false},
            new Product{ Name = "Bruin" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 4, Highlight=false},
            new Product{ Name = "Groot wit" , Price = 2.25m,Description = "Voor de grote honger een ongezouten op steengebakken", CategoryId = 4, Highlight=false},
            new Product{ Name = "Vierkant wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 6, Highlight=false},
            new Product{ Name = "Acht" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 5, Highlight=false},
            new Product{ Name = "Suisse" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 6, Highlight=false }
                };
                foreach (Product s in products)
                {
                    _ctx.Products.Add(s);
                }
                _ctx.SaveChanges();

                var newsMessages = new NewsMessages[]
                {
                new NewsMessages{Title = "Nieuwe Site", Message="Welcome op de nieuwe site", publication=true, StartDate= DateTime.Parse("30-10-2019"), EndDate= DateTime.Parse("01-07-2019")},
                new NewsMessages{Title = "verlof", Message="verlof van 1 april tot en met 5 april", publication=true,  StartDate= DateTime.Parse("30-10-2019"), EndDate= DateTime.Parse("01-07-2019")},
                 new NewsMessages{Title = "verlof", Message="verlof van 1 januari tot en met 5 maart", publication=false}
                };

                foreach (NewsMessages n in newsMessages)
                {
                    _ctx.NewsMessages.Add(n);
                }
                _ctx.SaveChanges();

                var customers = new Customer[]
                {
            new Customer{ Name = "Benny", Address = "Hobbystraat", Nr = 10, City = "Studentenstad", Zipcode = 8000, Country = "Belgie", Email = "Benny@email.com"},

                };
                foreach (Customer e in customers)
                {
                    _ctx.Customers.Add(e);
                }
                _ctx.SaveChanges();



                var orders = new Order[]
                {
            new Order{ CustomerId = 1 },

                };
                foreach (Order e in orders)
                {
                    _ctx.Orders.Add(e);
                }
                _ctx.SaveChanges();



                var orderlines = new OrderLine[]
                {
            new OrderLine{ Quantity = 5, ProductId= 1,  OrderId= 1 },

                };
                foreach (OrderLine e in orderlines)
                {
                    _ctx.OrderLines.Add(e);
                }
                _ctx.SaveChanges();

                var contactTopic = new topicsContactForm[]
                {
                new topicsContactForm{ Title ="Info over bestellingen, afhalingen."},
                new topicsContactForm{Title = "info over een product die niet in de lijst staat."},
                new topicsContactForm{Title = "Tehcnische probleem met de site of suggesties."}
                };

                foreach (topicsContactForm ct in contactTopic)
                {
                    _ctx.topicsContactforms.Add(ct);
                }
                _ctx.SaveChanges();


            }
        }
    }
}
