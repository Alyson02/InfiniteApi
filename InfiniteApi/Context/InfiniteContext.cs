using InfiniteApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InfiniteApi.Context
{
    public class InfiniteContext : DbContext
    {
        public InfiniteContext(DbContextOptions<InfiniteContext> opt) : base(opt)
        {

        }

        //DataSets

        public DbSet<CupomEntity> Cupom { get; set; }

    }
}
