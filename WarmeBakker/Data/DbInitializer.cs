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

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{ Name="Brood", Description = "Alle brood word op steen gebakken", Publication=true},
            new Category{ Name="Taarten", Description = "Alle brood word op steen gebakken", Publication=true},
            new Category{ Name="Boterkoeken", Description = "Alle brood word op steen gebakken", Publication=true}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();


            var subcategories = new SubCategory[]
            {
            new SubCategory{ Name="Wit", Description = "Witte broden", Publication=true, CategoryId = 1},
            new SubCategory{ Name="Fruit", Description = "Fruittaarten", Publication=true, CategoryId = 2},
            new SubCategory{ Name="Pudding", Description = "Boterkoeken met pudding", Publication=true, CategoryId = 3}
            };
            foreach (SubCategory c in subcategories)
            {
                context.SubCategories.Add(c);
            }
            context.SaveChanges();



            var products = new Product[]
            {
            new Product{ Name = "Vierkant" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 1,},
            new Product{ Name = "Rond" , Price = 2.25m, Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 1},
            new Product{ Name = "Lang" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 1},
            new Product{ Name = "Aardbei" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 2},
            new Product{ Name = "Pruimen" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 2},
            new Product{ Name = "Acht" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 3},
            new Product{ Name = "Hoorntje" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 3},
            new Product{ Name = "Suisse" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", Highlight=false, SubCategoryId = 3 }
            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
            }
            context.SaveChanges();

            var newsMessages = new NewsMessages[]
            {
                new NewsMessages{Title = "Nieuwe Site", Message="Welcome op de nieuwe site", publication=true, StartDate= DateTime.Parse("30-10-2019"), EndDate= DateTime.Parse("01-07-2019")},
                new NewsMessages{Title = "verlof", Message="verlof van 1 april tot en met 5 april", publication=false,  StartDate= DateTime.Parse("30-10-2019"), EndDate= DateTime.Parse("01-07-2019")},
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
        }

    }
}
