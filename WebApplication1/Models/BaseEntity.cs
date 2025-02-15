﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public string DeletedBy { get; set; }

    }
}
