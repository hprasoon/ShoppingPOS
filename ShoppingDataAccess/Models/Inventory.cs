using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingDataAccess.Models
{
    public class Inventory
    {
        public Inventory()
        {
        }

        [Key]
        public long inventory_Id { get; set; }
        public long product_Id;
        public float product_Unit;
        public DateTime updated_Date;
    }
}
