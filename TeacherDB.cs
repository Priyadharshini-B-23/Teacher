using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.EntityFrameworkCore.Extensions;


namespace mysqlefcore
{
  public class TeacherContext : DbContext
  {
    public DbSet<Teacher> Teacher_Data { get; set; }
    
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySQL("server=localhost;database=teachermanagement;user=root;password=Password@12345");
      // IConfigurationRoot configuration = new ConfigurationBuilder()
      //               .SetBasePath(Directory.GetCurrentDirectory())
      //               .AddJsonFile("appsettings.json")
      //               .Build();


      //           string connectionString = configuration.GetConnectionString("DefaultConnection");


      //           optionsBuilder.UseMySQL(connectionString);
     IConfigurationRoot configuration = new ConfigurationBuilder().
              SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();


                string connectionString = configuration.GetConnectionString("DefaultConnection");


                optionsBuilder.UseMySQL(connectionString);
 }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);


     
      modelBuilder.Entity< Teacher>(entity =>
      {
        entity.HasKey(e => e.Teacher_ID);
        entity.Property(e => e.Teacher_Name).IsRequired();
        entity.Property(e => e.Teacher_EmailID).IsRequired();
        entity.Property(e => e.Teacher_Qualification).IsRequired();
        entity.Property(e => e.Teacher_Location).IsRequired();
      });
    }
  }

}
 
 


  

