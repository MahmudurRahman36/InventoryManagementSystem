using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InventoryManagementSystem.Models.Entity;

namespace InventoryManagementSystem.Models
{
    public class InventoryDBContext:DbContext
    {
        public DbSet<Group> Groups{get;set;}
        public DbSet<Item> Items{get;set;}
        public DbSet<ItemShop> ItemShops{get;set;}
    }
}