using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class ItemContext: DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
