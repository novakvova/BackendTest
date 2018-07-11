using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend
{
    public class QuizeContext : DbContext
    {
        public QuizeContext(DbContextOptions<QuizeContext> options)
            : base(options)
        {

        }
        public DbSet<Models.Question> Questions { get; set; }
    }
}
