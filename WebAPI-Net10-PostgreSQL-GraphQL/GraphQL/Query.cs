using WebAPI_Net10_PostgreSQL_GraphQL.Data;
using WebAPI_Net10_PostgreSQL_GraphQL.Models;
using Microsoft.EntityFrameworkCore;
using HotChocolate.Data;

namespace WebAPI_Net10_PostgreSQL_GraphQL.GraphQL;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<Categoria> GetCategorias(IDbContextFactory<AppDbContext> contextFactory)
    {
        // Criamos o contexto temporário de forma segura
        var context = contextFactory.CreateDbContext();
        return context.Categorias;
    }

    [UseFiltering]
    [UseSorting]
    public IQueryable<Produto> GetProdutos(IDbContextFactory<AppDbContext> contextFactory)
    {
        var context = contextFactory.CreateDbContext();
        return context.Produtos;
    }
}
