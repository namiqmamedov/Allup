using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class LayoutServices : ILayoutServices
    {
        private readonly AppDbContext _context; 
        public LayoutServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string,string>> GetSettingsAsync()
        { 
            return await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
        }
    }
}
