using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace webAPI_Student.Models
{
	public class ApplicationDbContext: DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)

		{

		}
		public DbSet<Student> Students { get; set; }
	}
}

