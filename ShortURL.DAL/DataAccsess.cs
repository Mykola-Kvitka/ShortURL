using ShortURL.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShortURL.DAL
{
    public class DataAccsess : DbContext
    {
        public DataAccsess(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<URLEntity> URLs { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new List<UserEntity>(){
                new UserEntity() { Id = 1, Password = "admin", Role = "admin", Username = "admin" },
                new UserEntity() {Id =2, Password="user", Role="user", Username="user" } 
                });            
        }
    }
}
