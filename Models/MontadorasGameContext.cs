using Microsoft.EntityFrameworkCore;

namespace MontadorasGameApi.Models
{
    public class MontadorasGameContext : DbContext
    {
        public MontadorasGameContext(DbContextOptions<MontadorasGameContext> options)
            : base(options)
        {
        }

        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
    }
}