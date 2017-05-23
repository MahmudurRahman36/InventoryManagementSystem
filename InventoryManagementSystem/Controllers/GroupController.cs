using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.BLL;
using InventoryManagementSystem.Models.Entity;

namespace InventoryManagementSystem.Controllers
{
    public class GroupController : Controller
    {
        //
        // GET: /Group/
        GroupManager _groupManager = new GroupManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddGroup()
        {
            ViewBag.GroupList = _groupManager.GetAllGroup();
            return View();
        }
        [HttpPost]
        public ActionResult AddGroup(Group group)
        {
            ViewBag.GroupList = _groupManager.GetAllGroup();
            if (ModelState.IsValid)
            {
                try
                {
                    if (_groupManager.IsGroupExist(group))
                    {
                        ViewBag.saveConfirmMsg = "Group Name Already Exist";
                    }
                    else if (_groupManager.SetGroup(group))
                    {
                        ViewBag.saveConfirmMsg = "Successfully Added!..";
                        ViewBag.GroupList = _groupManager.GetAllGroup();
                    }
                    else
                    {
                        ViewBag.saveConfirmMsg = "Some Error Occured";
                    }
                    ViewBag.GroupList = _groupManager.GetAllGroup();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
                return View(group);
            }
            ViewBag.saveConfirmMsg = "Please Fill All Field";
            return View(group);
        }

    }
}
