using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.Basket
{
    public class BasketVM
    {
        public int Id { get; set; }
        public int Count { get; set; } // cookiedeki countu bilmek ucun
        public string Title { get; set; }
        public double Price { get; set; }
        public string Image{ get; set; }
        public double ExTax { get; set; }
    }
}
