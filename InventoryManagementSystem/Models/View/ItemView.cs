using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models.View
{
    public class ItemView
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
    }
}