using Microsoft.EntityFrameworkCore;
using FilmesAPI.Models;

namespace FilmesAPI.Data
{
  public class AppDbContext : DbContext
  {
    // Conexão
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    // Configuração Fluent API
    protected override void OnModelCreating(ModelBuilder builder){
        // Relacionamento 1-1
        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); // declara < > quando é 1-1

        // Relacionamento 1-N
        builder.Entity<Cinema>()
            .HasOne(cinema => cinema.Gerente)
            .WithMany(gerente => gerente.Cinemas)
            .HasForeignKey(cinema => cinema.GerenteId)
            .OnDelete(DeleteBehavior.Restrict); // para NÃO ser deleção em cascata

        // Relacionamento N-N
        // Se não fizesse essa configuração, automaticamente criaria a tabela CinemaFilme com FKs
        // Dessa forma abaixo, é possível definir uma tabela específica para o rel. N-N
        // Em vez de ficar a tabela CinemaFilme, ficará Sessao
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        // Permitir FK Null
        builder.Entity<Cinema>().Property(x => x.GerenteId).IsRequired(false); // permite NULL, requer também alterar int para int? na Model
        base.OnModelCreating(builder);
    }

    // Configuração das tabelas, ORM
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Gerente> Gerentes { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
  }
}
