using WebAPI_Net10_PostgreSQL_GraphQL.Data;
using WebAPI_Net10_PostgreSQL_GraphQL.Models;
using WebAPI_Net10_PostgreSQL_GraphQL.DTOs;
using Microsoft.EntityFrameworkCore;
using HotChocolate;

namespace WebAPI_Net10_PostgreSQL_GraphQL.GraphQL;

public class Mutation
{
    // --- CRUD CATEGORIA ---

    public async Task<Categoria> AddCategoriaAsync(CriarCategoriaInput input, IDbContextFactory<AppDbContext> contextFactory)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var categoria = new Categoria { Nome = input.Nome };

        context.Categorias.Add(categoria);
        await context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> UpdateCategoriaAsync(AtualizarCategoriaInput input, IDbContextFactory<AppDbContext> contextFactory)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var categoria = await context.Categorias.FindAsync(input.Id)
            ?? throw new GraphQLException("Categoria não encontrada.");

        categoria.Nome = input.Nome;
        await context.SaveChangesAsync();
        return categoria;
    }

    public async Task<bool> DeleteCategoriaAsync(int id, IDbContextFactory<AppDbContext> contextFactory)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var categoria = await context.Categorias.FindAsync(id);
        if (categoria == null) return false;

        context.Categorias.Remove(categoria);
        await context.SaveChangesAsync();
        return true;
    }

    // --- CRUD PRODUTO ---

    public async Task<Produto> AddProdutoAsync(CriarProdutoInput input, IDbContextFactory<AppDbContext> contextFactory)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        // Verifica se a categoria informada existe no banco de dados
        var categoriaExiste = await context.Categorias.AnyAsync(c => c.Id == input.CategoriaId);
        if (!categoriaExiste)
            throw new GraphQLException("A Categoria informada não existe.");

        var produto = new Produto
        {
            Nome = input.Nome,
            Preco = input.Preco,
            CategoriaId = input.CategoriaId
        };

        context.Produtos.Add(produto);
        await context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> UpdateProdutoAsync(AtualizarProdutoInput input, IDbContextFactory<AppDbContext> contextFactory)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var produto = await context.Produtos.FindAsync(input.Id)
            ?? throw new GraphQLException("Produto não encontrado.");

        var categoriaExiste = await context.Categorias.AnyAsync(c => c.Id == input.CategoriaId);
        if (!categoriaExiste)
            throw new GraphQLException("A Categoria informada não existe.");

        produto.Nome = input.Nome;
        produto.Preco = input.Preco;
        produto.CategoriaId = input.CategoriaId;

        await context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> DeleteProdutoAsync(int id, IDbContextFactory<AppDbContext> contextFactory)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var produto = await context.Produtos.FindAsync(id);
        if (produto == null) return false;

        context.Produtos.Remove(produto);
        await context.SaveChangesAsync();
        return true;
    }
}
