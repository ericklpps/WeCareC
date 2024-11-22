using Microsoft.EntityFrameworkCore;
using WeCare.Models;

namespace WeCare.Data
{
    public class WeCareDbContext : DbContext
    {
        public WeCareDbContext(DbContextOptions<WeCareDbContext> options) : base(options)
        {
        }

        public DbSet<Meta> Metas { get; set; }
        public DbSet<MetaUsuario> MetaUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "User Id=rm553927;Password=300903;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SID=orcl)));";
                optionsBuilder.UseOracle(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meta>(entity =>
            {
                entity.ToTable("GS_META");
                entity.HasKey(e => e.MetaId);
                entity.Property(e => e.MetaId).HasColumnName("META_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO").IsRequired();
                entity.Property(e => e.Categoria).HasColumnName("CATEGORIA");
                entity.Property(e => e.EconomiaEstimativa).HasColumnName("ECONOMIA_ESTIMATIVA");
                entity.Property(e => e.Prazo).HasColumnName("PRAZO").IsRequired();
            });

            modelBuilder.Entity<MetaUsuario>(entity =>
            {
                entity.ToTable("GS_METAUSUARIO");
                entity.HasKey(e => e.MetaUsuarioId);
                entity.Property(e => e.MetaUsuarioId).HasColumnName("META_USUARIO_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");
                entity.Property(e => e.MetaId).HasColumnName("META_ID");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.DataConclusao).HasColumnName("DATA_CONCLUSAO");
                entity.Property(e => e.DescricaoPersonalizada).HasColumnName("DESCRICAO_PERSONALIZADA");
                entity.Property(e => e.Prazo).HasColumnName("PRAZO").IsRequired();
            });
        }
    }
}
