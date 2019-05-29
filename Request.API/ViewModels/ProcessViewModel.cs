using Request.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class ProcessViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActionViewModel> Actions { get; set; }
        public ICollection<StateViewModel> States { get; set; }
        public ICollection<NodeViewModel> Nodes { get; set; }
        public ICollection<TransitionRuleViewModel> Rules { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
        public ICollection<ActivityViewModel> Activities { get; set; }
    }
}
