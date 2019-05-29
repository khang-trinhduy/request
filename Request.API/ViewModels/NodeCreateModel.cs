using System.Collections.Generic;
using Request.API.Models;

namespace Request.API.ViewModels
{
    public class NodeCreateModel
    {
        public List<Node> Childs { get; set; }
        public Node Parent { get; set; }
        public bool Iscompleted { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public List<ActivityCreateModel> Activities { get; set; }
        public List<RoleCreateModel> Roles { get; set; }
        public List<ActionCreateModel> Actions { get; set; }
    }
}