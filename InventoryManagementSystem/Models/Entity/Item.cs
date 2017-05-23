using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models.Entity
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<ItemShop> ItemShops { get; set; }
    }
}