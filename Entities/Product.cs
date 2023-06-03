
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core7_angular14_azure.Helpers;

namespace core7_angular14_azure.Entities
{
    
[Table("products")]
public class Product {

        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("descriptions")]
        public string descriptions { get; set; }

        [Column("qty")]
        public int qty { get; set; }

        [Column("unit")]
        public string unit { get; set; }

        [Column("cost_price",TypeName="decimal(10,2)")]
        public decimal cost_price { get; set; }

        [Column("sell_price",TypeName="decimal(10,2)")]
        public decimal sell_price { get; set; }

        [Column("prod_pic")]
        public string prod_pic { get; set; }

        [Column("category")]
        public string category { get; set; }

        [Column("sale_price",TypeName="decimal(10,2)")]
        public decimal sale_price { get; set; }

        [Column("alert_level")]
        public int alert_level { get; set; }

        [Column("critical_level")]
        public int critical_level { get; set; }

        [NotMapped]
        public int TotalPage { get; set;}

        [NotMapped]
        public int Page { get; set; }
        // [Column("datecreated")]
        // public DateTime datecreated { get; set; }

    //     [Column("dateupdated")]
    //     public DateTime dateupdated { get; set; }
    }    
}