using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrderService.Models
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
    }
}
