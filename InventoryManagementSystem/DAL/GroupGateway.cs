using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Entity;

namespace InventoryManagementSystem.DAL
{
    public class GroupGateway
    {
        InventoryDBContext _db = new InventoryDBContext();
        public List<Group> GetAllGroup() 
        {
            try
            {
                return _db.Groups.OrderBy(c => c.GroupName).ToList();
            }
            catch (Exception)
            {
                throw;
            }    
        }
        public int SetGroup(Group group)
        {
            try
            {
                _db.Groups.Add(group);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsGroupExist(Group group)
        {
            try
            {
                return _db.Groups.Any(c => c.GroupName == group.GroupName);
            }
            catch (Exception)
            {
                throw;
            }  
        }
    }
}