using Microsoft.EntityFrameworkCore;
using WebAPI_Net10_PostgreSQL_GraphQL.Models;

namespace WebAPI_Net10_PostgreSQL_GraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Produto> Produtos => Set<Produto>();
    }
}
