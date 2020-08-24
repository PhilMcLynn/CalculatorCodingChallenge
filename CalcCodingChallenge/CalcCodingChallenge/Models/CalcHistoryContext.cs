using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcCodingChallenge.Models
{
    public class CalcHistoryContext : DbContext
    {
        public CalcHistoryContext()
        {           
        }
        public CalcHistoryContext( DbContextOptions<CalcHistoryContext> options)
            :base(options)
        {
        }
        public DbSet<CalcHistory> CalcHistories { get; set; }
    }
}
