using core7_angular14_azure.Entities;
using core7_angular14_azure.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using core7_angular14_azure.Models;
using Microsoft.Data.SqlClient;

namespace core7_angular14_azure.Services
{

    public interface IProductService {
        IEnumerable<Product> ListAll(int page);
        IEnumerable<Product> SearchAll(string key);
        IEnumerable<Product> Dataset();

        int TotPage();
    }

    public class ProductService : IProductService
    {

    private DataDbContext _context;
        private readonly AppSettings _appSettings;


        public ProductService(DataDbContext context,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }        
        public int TotPage() {
            var perpage = 5;
            var totrecs = _context.Products.Count();
            int totpage = (int)Math.Ceiling((float)(totrecs) / perpage);
            return totpage;
        }
        public IEnumerable<Product> ListAll(int page)
        {
            // var products = _context.Products.ToList();
            var perpage = 5;
            // var totrecs = _context.Products.Count();
            // int totpage = (int)Math.Ceiling((float)(totrecs) / perpage);
            var offset = (page -1) * perpage;

            var products = _context.Products                                
                .OrderBy(b => b.id)
                .Skip(offset)
                .Take(perpage)
                .ToList();

            return products;
            // throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchAll(string key)
        {
            var columnName = "descriptions";
            var columnValue = new SqlParameter("columnValue", "%" + key + "%");
            var products = _context.Products.FromSqlRaw($"SELECT * FROM [Products] WHERE {columnName} LIKE @columnValue", columnValue).ToList();
            return products;
        }

        public IEnumerable<Product> Dataset()
        {
            var products = _context.Products.ToList();
            return products;
        }
    }
}