using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Infra.Configuration
    
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options ) : base(options)
        {
            
        }

        public DbSet<SistemaFinanceiro> sistemaFinanceiro { get; set; }

        public DbSet<UsuarioSistemaFinanceiro> usuarioSistemaFinanceiro { get; set; }

        public DbSet<Categoria> categorias { get; set; }

        public DbSet<Despesa> despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);

            }

        }

        public string ObterStringConexao()
        {
            return "Data Source=WIN-VLVMF5SRQ5J\\SQLEXPRESS; Initial Catalog=FINANCEIRO_2023; Integrated Security=False; User ID=sa; Password=mbl2009; Connection Timeout=15;";

        }

    }
}
