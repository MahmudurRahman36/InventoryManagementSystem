using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.BLL;
using InventoryManagementSystem.Models.Entity;

namespace InventoryManagementSystem.Controllers
{
    public class ItemController : Controller
    {
        ItemManager _itemManager = new ItemManager();
        GroupManager _groupManager = new GroupManager();
        public ActionResult AddItem()
        {
            ViewBag.GroupList = _groupManager.GetAllGroup();
            ViewBag.ItemList = _itemManager.GetAllItem();
            return View();
        }
        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            ViewBag.GroupList = _groupManager.GetAllGroup();
            if (ModelState.IsValid)
            {
                try
                {
                    if (_itemManager.IsItemExist(item))
                    {
                        ViewBag.saveConfirmMsg = "Item Name Already Exist";
                    }
                    else if (_itemManager.SetItem(item))
                    {
                        ViewBag.saveConfirmMsg = "Successfully Added!..";
                    }
                    else
                    {
                        ViewBag.saveConfirmMsg = "Some Error Occured";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.saveConfirmMsg = ex.Message;
                }
            }
            ViewBag.ItemList = _itemManager.GetAllItem();
            ViewBag.saveConfirmMsg = "Please Fill All Field";
            return View(item);
        }
        public ActionResult AddItemShop()
        {
            ViewBag.GroupList = _groupManager.GetAllGroup();
            ViewBag.ItemShopViewList = _itemManager.GetAllItemShop();
            return View();
        }
        public JsonResult GetItemList(int groupId)
        {
            var groupList = _itemManager.GetAllItemByGroup(groupId);
            return Json(groupList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddItemShop(ItemShop itemShop)
        {
            ViewBag.GroupList = _groupManager.GetAllGroup();
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (_itemManager.AddItemToShop(itemShop))
                    {
                        ViewBag.saveConfirmMsg = "Successfully Added!..";
                    }
                    else
                    {
                        ViewBag.saveConfirmMsg = "Item Quantity Can not be Negative";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.saveConfirmMsg = ex.Message;
                }
                ViewBag.ItemShopViewList = _itemManager.GetAllItemShop();
                return View(itemShop);
            }
            ViewBag.ItemShopViewList = _itemManager.GetAllItemShop();
            ViewBag.saveConfirmMsg = "Please Fill All Field";
            return View(itemShop);
        }

    }
}
