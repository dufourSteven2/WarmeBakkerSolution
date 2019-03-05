using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Nr { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}
