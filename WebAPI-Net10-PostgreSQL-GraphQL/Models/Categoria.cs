namespace WebAPI_Net10_PostgreSQL_GraphQL.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
