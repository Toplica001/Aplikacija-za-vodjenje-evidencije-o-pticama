namespace Models;

public class Context : DbContext
{
    public required DbSet<Ptica> Ptice { get; set; }
    public required DbSet<NepoznataPtica> Nepoznate { get; set; }
    public required DbSet<Osobina> Osobine { get; set; }
    public required DbSet<Podrucje> Podrucja { get; set; }
    public required DbSet<Vidjenje> Vidjenja { get; set; }

    public Context(DbContextOptions options) : base(options)
    {

    }
}
