using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingDataAccess.Models
{
    public class Product
    {
        public Product()
        {
        }

        [Key]
        public long product_Id { get; set; }
        public string product_Name { get; set; }
        public string product_Company { get; set; }
        public string product_Description { get; set; }
        public DateTime mfg_Date { get; set; }
        public DateTime exp_Date { get; set; }
        public bool isActive { get; set; }
    }
}
