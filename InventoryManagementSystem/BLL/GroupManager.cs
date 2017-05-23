using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementSystem.DAL;
using InventoryManagementSystem.Models.Entity;

namespace InventoryManagementSystem.BLL
{
    public class GroupManager
    {
        GroupGateway _groupGateway=new GroupGateway();
        public List<Group> GetAllGroup()
        {
            return _groupGateway.GetAllGroup();
        }
        public bool SetGroup(Group group)
        {
            if (_groupGateway.SetGroup(group) > 0) 
            {
                return true;
            }
            return false;
        }
        public bool IsGroupExist(Group group)
        {
            return _groupGateway.IsGroupExist(group);
        }
    }
}