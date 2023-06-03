using Microsoft.EntityFrameworkCore;
using core7_angular14_azure.Entities;

namespace core7_angular14_azure.Helpers
{

   public class DataDbContext : DbContext
    {

        // public DataDbContext(DbContextOptions<DataDbContext> options): base(options){
        // }        

        protected readonly IConfiguration Configuration;

        public DataDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }

}