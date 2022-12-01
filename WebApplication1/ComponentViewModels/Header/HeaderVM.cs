using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels.Basket;

namespace WebApplication1.ComponentViewModels.Header
{
    public class HeaderVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BasketVM> BasketVMs { get; set; }
    }
}
