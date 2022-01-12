using Microsoft.EntityFrameworkCore;
using AthleteApi.Models;

namespace AthleteApi;

public class AthleteContext : DbContext
{
    public AthleteContext(DbContextOptions<AthleteContext> options) : base(options) { }

    public DbSet<Athlete> Athletes { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Championship> Championships { get; set; }
}
