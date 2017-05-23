using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Entity;
using InventoryManagementSystem.Models.View;
namespace InventoryManagementSystem.DAL
{
    public class ItemGateway
    {
        InventoryDBContext _db = new InventoryDBContext();
        public List<Item> GetAllItem()
        {
            try
            {
                return _db.Items.Include("Group").OrderBy(c => c.ItemName).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Item> GetAllItemByGroup(int groupId)
        {
            try
            {
                return _db.Items.Where(c => c.GroupId == groupId).ToList();
            }
            catch (Exception)
            {
                throw;
            }  
        }
        public int SetItem(Item item)
        {
            try
            {
                _db.Items.Add(item);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }        
        }
        public bool IsItemExist(Item item)
        {
            try
            {
                return _db.Items.Any(c => c.ItemName == item.ItemName);
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public List<ItemShop> GetAllItemShop()
        {
            try
            {
                return _db.ItemShops.Include("Item").Include("Item.Group").OrderBy(c => c.Item.ItemName).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ItemShop GetItemFromShopByItemId(ItemShop itemShop)
        {
            try
            {
                return _db.ItemShops.AsNoTracking().Where(c => c.ItemId == itemShop.ItemId).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ModifiyItemShop(ItemShop itemShop) 
        {
            try
            {
                int rowAffected = 0;
                using (var _db = new InventoryDBContext())
                {
                    _db.Entry(itemShop).State = System.Data.Entity.EntityState.Modified;
                    rowAffected = _db.SaveChanges();
                }
                return rowAffected;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int SetItemShop(ItemShop itemShop)
        {
            try
            {
                _db.ItemShops.Add(itemShop);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}