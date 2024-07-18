using Microsoft.EntityFrameworkCore;
using OnlyShare.Database.Models;
using System.Reflection.Emit;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Question>()
        .Property(q => q.Tags)
        .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => Enum.Parse<Tag>(s)).ToList()
        );

        modelBuilder.Entity<Question>()
        .HasMany(e => e.Answers)
        .WithOne(e => e.Question)
        .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<User>()
            .HasMany(e => e.Questions)
            .WithOne(e => e.User)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<User>()
            .HasMany(e => e.Answers)
            .WithOne(e => e.User)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<WeatherForecast>().HasData(new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now.AddYears(-2),
            Summary = "Weather 1",
            TemperatureC = 30,
        });
        modelBuilder.Entity<WeatherForecast>().HasData(new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now.AddYears(-1),
            Summary = "Weather 2",
            TemperatureC = 35,
        });
        modelBuilder.Entity<WeatherForecast>().HasData(new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            Summary = "Weather 3",
            TemperatureC = 40,
        });
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Question> Questions { get; set; } = default!;
    public DbSet<Answer> Answers { get; set; } = default!;
    public DbSet<ResetToken> ResetTokens { get; set; } = default!;
    public DbSet<UserVote> UserVotes { get; set; } = default!;

}