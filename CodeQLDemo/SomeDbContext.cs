using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CodeQLDemo
{
    public class SomeDbContext : DbContext
    {
        public SomeDbContext():base(new DbContextOptionsBuilder<SomeDbContext>().UseSqlServer(new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BlazorFormSample;UserName=hasallthepower;Password=mygreatpassword1!")).Options)
        {
            
        }
        public DbSet<MyEntity> MyEntities { get; set; }
    }
    
    public class MyEntity
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            using SomeDbContext dbContext = new SomeDbContext();
            Console.WriteLine(dbContext.MyEntities.Find(1).Name);
        }
    } 
}
