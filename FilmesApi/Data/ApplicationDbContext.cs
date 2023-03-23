using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
        : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.Entity<Sessao>().HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });
        
        builder.Entity<Sessao>().HasOne(sessao => sessao.Cinema).WithMany(cinema=>cinema.Sessoes).HasForeignKey(sessao=>sessao.CinemaId);

        builder.Entity<Sessao>().HasOne(sessao=>sessao.Filme).WithMany(filme=>filme.Sessoes).HasForeignKey(sessao=>sessao.FilmeId);

        builder.Entity<Cinema>()
        .HasMany(p => p.Funcionarios)
        .WithOne(i => i.Cinema)
        .HasForeignKey(i => i.CinemaId);

    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }


}
