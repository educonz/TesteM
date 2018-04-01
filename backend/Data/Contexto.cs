using Core.Configuration;
using Core.Provider.EntityFramework;
using Core.Provider.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Data
{
    public class Contexto : EntityFrameworkContext
    {
        private readonly string _connection;

        public Contexto(string connection)
        {
            _connection = connection;
        }

        public Contexto(IAppConfiguration appConfiguration)
        {
            _connection = appConfiguration.Configuration["ConnectionStrings:DefaultConnection"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(typeof(Contexto).GetTypeInfo().Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connection))
            {
                optionsBuilder.UseSqlServer(_connection);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
