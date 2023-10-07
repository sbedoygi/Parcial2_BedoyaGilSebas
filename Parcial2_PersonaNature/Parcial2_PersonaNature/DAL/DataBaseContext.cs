using Microsoft.EntityFrameworkCore;
using Parcial2_PersonaNature.DAL.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Parcial2_PersonaNature.DAL
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<NaturalPerson> NaturalPerson { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NaturalPerson>().HasIndex(NaturalPerson => NaturalPerson.FullName).IsUnique();
        }


    }
}
