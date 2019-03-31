using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
   public class NewsMessages
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set;}
        public bool publication { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
