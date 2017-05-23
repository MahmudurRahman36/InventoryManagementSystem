using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models.Entity
{
    public class ItemShop
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "No Of Items")]
        public decimal NoOfItems { get; set; }
        [Required]
        [Display(Name = "Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}