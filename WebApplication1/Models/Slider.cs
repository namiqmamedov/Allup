using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Slider : BaseEntity
    {      
        [StringLength(2500)]
        public string MainTitle { get; set; }
        [StringLength(2500)]
        public string SubTitle { get; set; }
        [StringLength(2500)]
        public string Description { get; set; }
        [StringLength(2500)]
        public string  Image { get; set; }
        [StringLength(2500)]
        public string PageLink { get; set; }
    }
}
