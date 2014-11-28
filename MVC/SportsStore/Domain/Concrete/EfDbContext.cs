﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain
{
    public class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
