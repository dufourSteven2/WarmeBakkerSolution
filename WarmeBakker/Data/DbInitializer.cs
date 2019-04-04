using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarmeBakkerLib;
using WarmeBakker.Models;


namespace WarmeBakker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WarmeBakkerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var headCategories = new Category[]
            {
                new Category{Name="Brood", Description="alle soorten brood"},
                new Category{Name="Taarten", Description="alle soorten taarten"},
                 new Category{Name="Boterkoeken", Description="alle soorten boterkoeken"}
            };
            foreach (Category c in headCategories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
            new Category{ Name="Wit Brood", Description = "Alle Wit brood word op steen gebakken", HeadCategoryId = 1},
            new Category{ Name="Chocolade taart", Description = "Alle taarten met chocolade", HeadCategoryId = 2},
            new Category{ Name="Boterkoeken", Description = "Alle brood word op steen gebakken", HeadCategoryId = 3}
        
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();



            var products = new Product[]
            {
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken",  CategoryId = 1, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m, Description = "Wit brood ongezouten op steengebakken", CategoryId = 2, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 3, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 1, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 2, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 3, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 2, Highlight=false},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 1, Highlight=false }
            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
            }
            context.SaveChanges();

            var newsMessages = new NewsMessages[]
            {
                new NewsMessages{Title = "Nieuwe Site", Message="Welcome op de nieuwe site", publication=true, StartDate= DateTime.Parse("30-10-2019"), EndDate= DateTime.Parse("01-07-2019")},
                new NewsMessages{Title = "verlof", Message="verlof van 1 april tot en met 5 april", publication=true,  StartDate= DateTime.Parse("30-10-2019"), EndDate= DateTime.Parse("01-07-2019")},
                 new NewsMessages{Title = "verlof", Message="verlof van 1 januari tot en met 5 maart", publication=false}
            };

            foreach (NewsMessages n in newsMessages)
            {
                context.NewsMessages.Add(n);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
            new Customer{ Name = "Benny", Address = "Hobbystraat", Nr = 10, City = "Studentenstad", Zipcode = 8000, Country = "Belgie", Email = "Benny@email.com"},

            };
            foreach (Customer e in customers)
            {
                context.Customers.Add(e);
            }
            context.SaveChanges();



            var orders = new Order[]
            {
            new Order{ CustomerId = 1 },

            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();



            var orderlines = new OrderLine[]
            {
            new OrderLine{ Quantity = 5, ProductId= 1,  OrderId= 1 },

            };
            foreach (OrderLine e in orderlines)
            {
                context.OrderLines.Add(e);
            }
            context.SaveChanges();

            var contactTopic = new topicsContactForm[]
            {
                new topicsContactForm{ Title ="Info over bestellingen, afhalingen."},
                new topicsContactForm{Title = "info over een product die niet in de lijst staat."},
                new topicsContactForm{Title = "Tehcnische probleem met de site of suggesties."}
            };

            foreach (topicsContactForm ct in contactTopic)
            {
                context.topicsContactforms.Add(ct);
            }
            context.SaveChanges();

        }

       
    }
}
