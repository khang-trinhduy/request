using System.Collections.Generic;
using Request.API.Models;

namespace Request.API.ViewModels
{
    public class ProcessCreateModel
    {
        public string Name { get; set; }
        public ICollection<ActionCreateModel> Actions { get; set; }
        public ICollection<RuleCreateModel> Rules { get; set; }
        public ICollection<RoleCreateModel> Roles { get; set; }
        public ICollection<ActivityCreateModel> Activities { get; set; }
        public List<StateCreateModel> States { get; set; }
        public List<NodeCreateModel> Nodes { get; set; }

    }
}