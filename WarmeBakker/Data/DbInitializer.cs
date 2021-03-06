﻿using System;
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

            var categories = new Category[]
            {
            new Category{ Name="Brood", Description = "Alle brood word op steen gebakken"},
            new Category{ Name="Taarten", Description = "Alle brood word op steen gebakken"},
            new Category{ Name="Boterkoeken", Description = "Alle brood word op steen gebakken"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();



            var products = new Product[]
            {
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken",  CategoryId = 1},
            new Product{ Name = "Wit" , Price = 2.25m, Description = "Wit brood ongezouten op steengebakken", CategoryId = 2},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 3},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 1},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 2},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 3},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 2},
            new Product{ Name = "Wit" , Price = 2.25m,Description = "Wit brood ongezouten op steengebakken", CategoryId = 1}
            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
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
