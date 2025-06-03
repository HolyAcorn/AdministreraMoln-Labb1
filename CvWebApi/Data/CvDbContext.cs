using CvWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CvWebApi.Data;

public class CvDbContext : DbContext
{
    public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Competency> Competencies { get; set; }
    public DbSet<Project> Projects { get; set; }
}