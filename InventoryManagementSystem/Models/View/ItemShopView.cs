using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models.View
{
    public class ItemShopView
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string GroupName { get; set; }
        public decimal NoOfItems { get; set; }
    }
}