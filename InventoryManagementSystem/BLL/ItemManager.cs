using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementSystem.DAL;
using InventoryManagementSystem.Models.Entity;
using InventoryManagementSystem.Models.View;

namespace InventoryManagementSystem.BLL
{
    public class ItemManager
    {
        ItemGateway _itemGateway = new ItemGateway();
        public List<Item> GetAllItem()
        {
            return _itemGateway.GetAllItem();
        }
        public bool SetItem(Item item)
        {
            if (_itemGateway.SetItem(item) > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsItemExist(Item item)
        {
            return _itemGateway.IsItemExist(item);
        }
        public List<ItemShopView> GetAllItemShop()
        {
            List<ItemShop> itemShops=_itemGateway.GetAllItemShop();
            List<ItemShopView> itemShopViews=new List<ItemShopView>();
            foreach (ItemShop itemShop in itemShops) 
            {
                ItemShopView itemShopView = new ItemShopView()
                {
                    ItemName=itemShop.Item.ItemName,
                    GroupName=itemShop.Item.Group.GroupName,
                    NoOfItems=itemShop.NoOfItems
                };
                itemShopViews.Add(itemShopView);
            }
            return itemShopViews;
        }
        public List<Item> GetAllItemByGroup(int groupId)
        {
            return _itemGateway.GetAllItemByGroup(groupId);
        }
        public ItemShop GetItemFromShopByItemId(ItemShop itemShop) 
        {
            return _itemGateway.GetItemFromShopByItemId(itemShop);
        }
        public int ModifiyItemShop(ItemShop itemShop)
        {
            return _itemGateway.ModifiyItemShop(itemShop);
        }
        public int SetItemShop(ItemShop itemShop)
        {
            return _itemGateway.SetItemShop(itemShop);
        }
        public bool AddItemToShop(ItemShop itemShop)
        {
            ItemShop newItemShop = GetItemFromShopByItemId(itemShop);
            if (newItemShop != null) {
                newItemShop.NoOfItems = newItemShop.NoOfItems + itemShop.NoOfItems;
                if (ModifiyItemShop(newItemShop)>0) 
                {
                    return true;
                }
                return false;
            }
            else if (SetItemShop(itemShop) > 0)
            {
                return true;
            }
            return false;
        }
        public bool ReduceItemToShop(ItemShop itemShop)
        {
            ItemShop newItemShop = GetItemFromShopByItemId(itemShop);
            if (newItemShop != null)
            {
                newItemShop.NoOfItems = newItemShop.NoOfItems - itemShop.NoOfItems;
                if (newItemShop.NoOfItems >= 0)
                {
                    if (ModifiyItemShop(newItemShop) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}