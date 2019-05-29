using Request.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class NodeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public bool IsCompleted { get; set; }
        public List<ActivityViewModel> Activities { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public int ProcessId { get; set; }
        public List<NodeChildViewModel> Childs { get; set; }
        public List<ActionViewModel> Actions { get; set; }
    }
}
