using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models.Entity
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        public List<Item> Items { get; set; }
    }
}