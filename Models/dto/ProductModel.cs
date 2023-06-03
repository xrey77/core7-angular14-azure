using core7_angular14_azure.Helpers;

namespace core7_angular14_azure.Models.dto
{
    public class ProductModel {
        public int id { get; set; }
        public string descriptions { get; set; }
        public int qty { get; set; }
        public string unit { get; set; }
        public decimal cost_price { get; set; }
        public decimal sell_price { get; set; }
        public string prod_pic { get; set; }
        public string category { get; set; }
        public decimal sale_price { get; set; }
        public int alert_level { get; set; }
        public int critical_level { get; set; }
        // public DateTime datecreated { get; set; }
        // public DateTime dateupdated { get; set; }
    }    
}