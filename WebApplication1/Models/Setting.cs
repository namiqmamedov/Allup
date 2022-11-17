using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(2500)]
        public string Key { get; set; }
        [StringLength(2500)]
        public string Value { get; set; }
    }
}
