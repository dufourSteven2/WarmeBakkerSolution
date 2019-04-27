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
                new Category{Name="Brood", Description="alle soorten brood.", Publication = true},
                new Category{Name="Taarten", Description="alle soorten taarten.", Publication = true},
                 new Category{Name="Boterkoeken", Description="alle soorten boterkoeken.", Publication = false},
                  new Category{Name="Pistolets", Description="alle soorten pistolets.", Publication = false},
                   new Category{Name="Pateetjes", Description="alle soorten pateetjes.", Publication = false}
           };
                foreach (Category c in headCategories)
                {
                    _ctx.Categories.Add(c);
                }
                _ctx.SaveChanges();

                var categories = new Category[]
                {
                    //headcattegory brood
            new Category{ Name="Wit Brood", Description = "Alle soorten wit broot.", HeadCategoryId = 1},
            new Category{ Name="Brui Brood", Description = "Alle soorten bruin brood.", HeadCategoryId = 1},
            new Category{ Name="Brood Speciaal", Description = "Alle speeciale soorten brood.", HeadCategoryId = 1},
            new Category{ Name="Brood Weekend", Description = "Deze broden enkel verkrijbaar in het weekend", HeadCategoryId = 1},

                //headcategory taarten
            new Category{ Name="Drooggebak", Description = "Alle soorten drooggebak taarten.", HeadCategoryId = 2},
            new Category{ Name="Chocoladetaatten", Description = "Alle soorten Chocolade taarten.", HeadCategoryId = 2},
            new Category{ Name="Fruittaarten", Description = "Alle soorten fruit taarten.", HeadCategoryId = 2},
            new Category{ Name="Bavarois/marsepein", Description = "Alle soorten bavarois en marsepein taarten.", HeadCategoryId = 2},
            new Category{ Name="Bisquit", Description = "Alle soorten bisquit taarten.", HeadCategoryId = 2},

                // headcategory boterkoekekn
             new Category{ Name="Boterkoeken", Description = "Alle soorten boterkoeken.", HeadCategoryId = 3},
             new Category{ Name="Koffiekoeken", Description = "Alle soorten koffiekoeken.", HeadCategoryId = 3},
             new Category{ Name="Puddingkoeken", Description = "Alle alle soorten puddingkoeken.", HeadCategoryId = 3},

                //headcategory pistolets
            new Category{ Name="Harde pistolets", Description = "Alle soorten harde pistolets.", HeadCategoryId = 4},
            new Category{ Name="Zachte pistolet", Description = "Alle soorten zachte pistolets.", HeadCategoryId = 4},
            new Category{ Name="Sandwiches", Description = "Alle soorten sandwaches.", HeadCategoryId = 4},
            new Category{ Name="Ciabatta", Description = "Alle soorten ciabatta.", HeadCategoryId = 4},
            new Category{ Name="Apollo", Description = "Alle soorten apollo.", HeadCategoryId = 4},
            new Category{ Name="Stokbrood", Description = "Alle soorten stokboord.", HeadCategoryId = 4},
            new Category{ Name="Mini broodjes", Description = "Alle soorten mini broodjes.", HeadCategoryId = 4},

                //headcategory Pateetjes

             new Category{ Name="Pateetjes", Description = "Alle soorten Pateetjes.", HeadCategoryId = 5},

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
