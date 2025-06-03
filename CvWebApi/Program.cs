
using CvWebApi.Data;
using CvWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CvWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAuthorization();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<CvDbContext>(option =>
			{
				option.UseSqlServer(builder.Configuration.GetConnectionString("CvDbConnection"));
			});
			

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();



			app.MapPost("/api/competency", async (Competency competency, CvDbContext db) =>
			{
				await db.Competencies.AddAsync(competency);
				await db.SaveChangesAsync();
				return Results.Ok($"{competency.Name} added");
			});

			app.MapGet("/api/competencies", async (CvDbContext db) =>
			{
				return Results.Ok(await db.Competencies.ToListAsync());
			});

			app.MapGet("/api/competency/{id}", async (int id, CvDbContext db) =>
			{
				return Results.Ok(await db.Competencies.FirstOrDefaultAsync(d => d.Id == id));
			});

			app.MapDelete("/api/competency/{id}", async (int id, CvDbContext db) =>
			{
				Competency competency = await db.Competencies.FirstOrDefaultAsync(d => d.Id == id);
				if(competency == null) return Results.NotFound();
				db.Competencies.Remove(competency);
				await db.SaveChangesAsync();
				return Results.Ok($"{competency.Name} removed");
			});

			app.MapPut("/api/competency/{id}", async (int id, Competency newCompetency, CvDbContext db) =>
			{
				Competency competency = await db.Competencies.FirstOrDefaultAsync(d => d.Id == id);
				if(competency == null) return Results.NotFound();
				
				competency.Name = newCompetency.Name;
				competency.CompetencyLevel = newCompetency.CompetencyLevel;
				competency.YearsOfExperience = newCompetency.YearsOfExperience;
				await db.SaveChangesAsync();
				return Results.Ok($"{competency.Name} altered");
			});
			
			
			
			app.MapPost("/api/project", async (Project project, CvDbContext db) =>
			{
				await db.Projects.AddAsync(project);
				await db.SaveChangesAsync();
				return Results.Ok($"{project.Name} added");
			});

			app.MapGet("/api/projects", async (CvDbContext db) =>
			{
				return Results.Ok(await db.Projects.ToListAsync());
			});
			
			app.MapGet("/api/project/{id}", async (int id, CvDbContext db) =>
			{
				return Results.Ok(await db.Projects.FirstOrDefaultAsync(d => d.Id == id));
			});
			
			app.MapDelete("/api/project/{id}", async (int id, CvDbContext db) =>
			{
				Project project = await db.Projects.FirstOrDefaultAsync(d => d.Id == id);
				if(project == null) return Results.NotFound();
				db.Projects.Remove(project);
				await db.SaveChangesAsync();
				return Results.Ok($"{project.Name} removed");
			});
			
			app.MapPut("/api/project/{id}", async (int id, Project newProject, CvDbContext db) =>
			{
				Project project = await db.Projects.FirstOrDefaultAsync(d => d.Id == id);
				if(project == null) return Results.NotFound();
				
				project.Name = newProject.Name;
				project.Type = newProject.Type;
				project.Description = newProject.Description;
				project.Url = newProject.Url;
				await db.SaveChangesAsync();
				return Results.Ok($"{project.Name} altered");
			});

			app.Run();
		}
	}
}
