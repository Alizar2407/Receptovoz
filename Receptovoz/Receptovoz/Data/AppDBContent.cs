using Microsoft.EntityFrameworkCore;
using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            
        }

        public DbSet<Article> Article { get; set; }

        public DbSet<Recipe> Recipe { get; set; }
    }
}
