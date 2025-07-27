using ContagemPF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ContagemPF.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public ApplicationDbContext()
    {
    }

    public DbSet<Contagem> Contagens => Set<Contagem>();
    public DbSet<Mes> Meses => Set<Mes>();
}