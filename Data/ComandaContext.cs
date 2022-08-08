using Microsoft.EntityFrameworkCore;
using RestTest.Models;

namespace RestTest.Data
{
    public class ComandaContext :DbContext
    {
        public ComandaContext(DbContextOptions<ComandaContext> options)
            : base(options) { }

        public DbSet<ComandaModel> Comandas { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
