using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels.Basket;

namespace WebApplication1.Interface
{

    public interface ILayoutServices
    {
        Task<Dictionary<string,string>> GetSettingsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<BasketVM>> GetBasketAsync();
    }
}
