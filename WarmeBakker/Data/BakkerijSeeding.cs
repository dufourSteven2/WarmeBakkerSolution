﻿using System;
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
            new Category{ Name="Bruin Brood", Description = "Alle soorten bruin brood.", HeadCategoryId = 1},
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

                    //all white bread
            new Product{ Name = "Wit vierkant" , Price = 1.60m,Description = "Wit vierkant.",  CategoryId = 6, Highlight=false},
            new Product{ Name = "Wit rond" , Price = 1.60m,Description = "Wit rond.",  CategoryId = 6, Highlight=false},
            new Product{ Name = "Wit galet" , Price = 1.60m,Description = "Wit galet.",  CategoryId = 6, Highlight=false},
            new Product{ Name = "Wit sesam" , Price = 1.75m,Description = "Wit sesam.",  CategoryId = 6, Highlight=false},


                    //all brown bread
            new Product{ Name = "Bruin vierkant" , Price = 1.60m, Description = "Bruin vierkant.", CategoryId = 23, Highlight=false},
            new Product{ Name = "Bruin rond" , Price = 1.60m, Description = "Bruin rond.", CategoryId = 23, Highlight=false},
            new Product{ Name = "Bruin galet" , Price = 1.60m, Description = "Bruin galet", CategoryId = 23, Highlight=false},


                    //all special bread
             new Product{ Name = "Finesse" , Price = 1.75m, Description = "Donker meegranen.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Abdij" , Price = 1.75m, Description = "Grob brood met tarwevlokken", CategoryId = 22, Highlight=false},
             new Product{ Name = "Crunchy" , Price = 1.75m, Description = "Meergranen met krokante granen", CategoryId = 22, Highlight=false},
             new Product{ Name = "Pani Grain" , Price = 1.75m, Description = "Fijn meergranen, smaak meergranen en noten.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Pani vita" , Price = 1.75m, Description = "Grof meegragnen, zonnebloem en pompoenpitten.", CategoryId = 22, Highlight=false},
             new Product{ Name = "7-Granen" , Price = 1.75m, Description = "Fijn meegranen, textuur tussen bruin en volkoren.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Alpenfit" , Price = 1.75m, Description = "Donker meegranen.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Grof volkoren" , Price = 1.75m, Description = "Volkoren met extra zemelen en vezels.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Zonnebrood" , Price = 1.75m, Description = "Wit meegranen en zonnebloempitten.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Kappers" , Price = 1.75m, Description = "Donker meegranen", CategoryId = 22, Highlight=false},
             new Product{ Name = "Speltmeel" , Price = 1.75m, Description = "30% spelt 70% tarwe.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Maya" , Price = 1.75m, Description = "Donker meegranen met zonnebloempitten.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Bolero" , Price = 1.75m, Description = "Wit meergranen, maïsbolletjes en lijnzaad.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Hoevebrood" , Price = 1.75m, Description = "Zacht boerenbrood.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Volkoren" , Price = 1.75m, Description = "Volkoren.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Roggebrood" , Price = 1.75m, Description = "", CategoryId = 22, Highlight=false},
             new Product{ Name = "Duobrood" , Price = 1.75m, Description = "Helft wit, helft bruin.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Graaneveld" , Price = 1.75m, Description = "Fijn meergranen.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Bruin rozijn" , Price = 1.75m, Description = "Bruin brood met rozijnen.", CategoryId = 6, Highlight=false},
             new Product{ Name = "Meergranen" , Price =1.75m, Description = "", CategoryId = 22, Highlight=false},
             new Product{ Name = "Ardeens" , Price =1.75m, Description = "Wit brood met tarwevlokken.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Malt" , Price = 1.75m, Description = "Fijn meergranen", CategoryId = 22, Highlight=false},
             new Product{ Name = "Boerenbrood" , Price = 2.35m, Description = "Brood met krokante korst.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Vita plus" , Price = 2.65m, Description = "Vokoren en havermout.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Spelt 95%" , Price = 2.65m, Description = "95% spelt, 5% havermout.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Spelt / veenbes" , Price = 2.65m, Description = "Speltbrood met veenbessen.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Fjord" , Price = 2.65m, Description = "Donker meergranen met veel granen.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Quinoa" , Price = 2.65m, Description = "Grof meergranen met quionoa en grove granen.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Prolijntje" , Price = 2.90m, Description = "Koolhydraatarm brood.", CategoryId = 22, Highlight=false},
             new Product{ Name = "Appeltjesbrood" , Price = 4.10m, Description = "Zoet brood met appels en rozijnen", CategoryId = 22, Highlight=false},

             //all weekend bread
             new Product{ Name = "Notenbrood" , Price = 2.30m, Description = "Bruin brood met noten", CategoryId = 21, Highlight=false},
             new Product{ Name = "Veenbes/hazelnoot" , Price = 3.25m, Description = "Bruin brood met veenbessen en hazelnoten", CategoryId = 21, Highlight=false},
             new Product{ Name = "Roggemafke" , Price = 1.85m, Description = "Bruin rond broodje met rozijnen", CategoryId = 6, Highlight=false},
             new Product{ Name = "Koekebrood" , Price = 2.65m, Description = "", CategoryId = 21, Highlight=false},
             new Product{ Name = "Rozijnenbrood" , Price = 2.75m, Description = "", CategoryId = 21, Highlight=false},
             new Product{ Name = "Suikerbrood" , Price =2.75m, Description = "", CategoryId = 21, Highlight=false},
             new Product{ Name = "Chocoladebrood" , Price = 2.75m, Description = "", CategoryId = 21, Highlight=false},

             //boterkoeken
             new Product{ Name = "Gewone boterkoek" , Price = 1.15m, Description = "", CategoryId = 15, Highlight=false},
             new Product{ Name = "Boterkoek met rozijn" , Price = 1.15m, Description = "", CategoryId = 15, Highlight=false},
             new Product{ Name = "Chocoladekoek" , Price = 1.15m, Description = "", CategoryId = 15, Highlight=false},
             new Product{ Name = "Croissant" , Price = 1.15m, Description = "", CategoryId = 15, Highlight=false},

             //koffiekoeken
             new Product{ Name = "Croissant Frangipanne" , Price = 1.15m, Description = "", CategoryId = 14, Highlight=false},
             new Product{ Name = "Croisant chocolade" , Price = 1.15m, Description = "", CategoryId = 14, Highlight=false},
             new Product{ Name = "Frangipanne koek" , Price = 1.15m, Description = "m", CategoryId = 14, Highlight=false},
             new Product{ Name = "Appelkoek (moes)" , Price = 1.15m, Description = "Appelkoek met appelmoes.", CategoryId = 14, Highlight=false},
             new Product{ Name = "Appelschijfjes" , Price = 1.15m, Description = "Appelkoek met pudding.", CategoryId = 14, Highlight=false},
             new Product{ Name = "Kriekenkoek" , Price = 1.15m, Description = "", CategoryId = 14, Highlight=false},
             new Product{ Name = "Abrikozenkoek" , Price = 1.15m, Description = "", CategoryId = 14, Highlight=false},
             new Product{ Name = "Ananaskoek" , Price = 1.15m, Description = "", CategoryId = 14, Highlight=false},
             new Product{ Name = "Banaan chocolade" , Price = 1.15m, Description = "Koek met bananencreme en chocoladestukjes erin.", CategoryId = 14, Highlight=false},
             new Product{ Name = "Ronde suisse" , Price = 1.15m, Description = "Ronde koek met rozijnen", CategoryId = 14, Highlight=false},
             new Product{ Name = "Lange suisse" , Price = 1.15m, Description = "Lange koek met rozijnen.", CategoryId = 14, Highlight=false},
             new Product{ Name = "Chocolade suis" , Price = 1.15m, Description = "Lange koek met chocolade", CategoryId = 14, Highlight=false},
             new Product{ Name = "Achtkoek" , Price = 1.15m, Description = "", CategoryId = 14, Highlight=false},
             new Product{ Name = "Strik pudding" , Price = 1.15m, Description = "Koek met ingebakken pudding.", CategoryId = 14, Highlight=false},
             new Product{ Name = "Driehoek" , Price = 1.15m, Description = "Koek toegevouwd met ingebakken pudding.", CategoryId = 14, Highlight=false},

             //puddingkoeken
             new Product{ Name = "Croissant Créme" , Price = 1.30m, Description = "", CategoryId = 13, Highlight=false},
             new Product{ Name = "Vierkant créme bloem" , Price = 1.30m, Description = "Vierkant koek met patisserie créme en bloemsuiker erop", CategoryId = 13, Highlight=false},
             new Product{ Name = "Vierkant créme chocolade" , Price = 1.30m, Description = "Vierkant koek met patisserie créme en chocolade erop", CategoryId = 13, Highlight=false},



             new Product{ Name = "Met slagroom" , Price = 2.25m, Description = "Een caloriebom", CategoryId = 6, Highlight=false},

             new Product{ Name = "Met slagroom" , Price = 2.25m, Description = "Een caloriebom", CategoryId = 6, Highlight=false},
             new Product{ Name = "Met slagroom" , Price = 2.25m, Description = "Een caloriebom", CategoryId = 6, Highlight=false},
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
