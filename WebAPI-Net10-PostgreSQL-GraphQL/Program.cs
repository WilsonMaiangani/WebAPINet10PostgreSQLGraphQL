using ChilliCream.Nitro.App;
using Microsoft.EntityFrameworkCore;
using WebAPI_Net10_PostgreSQL_GraphQL.Data;
using WebAPI_Net10_PostgreSQL_GraphQL.GraphQL;


var builder = WebApplication.CreateBuilder(args);

// Configurar PostgreSQL via Factory Pool (necessário para paralelismo do GraphQL)
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar o GraphQL Server (Hot Chocolate)
// Configurar o GraphQL Server (Hot Chocolate moderno)
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();


// Add services to the container.
builder.Services.AddControllers();

// Suporte nativo ao OpenAPI do .NET 10
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Mapeia o endpoint do GraphQL (Padrão: /graphql)
//app.MapGraphQL();



// CORREÇÃO AQUI: Mapeia o endpoint usando o padrão de Delegate (Action) exigido pela v16
app.MapGraphQL().WithOptions(options =>
{
    options.Tool.ServeMode = ServeMode.Embedded;
});

app.UseAuthorization();

app.MapControllers();

app.Run();
