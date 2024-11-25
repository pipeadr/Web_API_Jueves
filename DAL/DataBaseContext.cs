using Microsoft.EntityFrameworkCore;
using Web_API_Jueves.DAL.Entities;

namespace Web_API_Jueves.DAL
{
    public class DataBaseContext :DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        // Este método es propio de EF CORE me sirve para configurar los indicis de cada campo de una tabka en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();//Aquí creo un indice
        }


        #region DbSets
        public DbSet<Country> Countries { get; set; }
        #endregion


    }
}
