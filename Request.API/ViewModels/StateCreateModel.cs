using System;
using System.Collections.Generic;
using Request.API.Models;

namespace Request.API.ViewModels
{
    public class StateCreateModel
    {
        public StateType StateType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ActivityCreateModel> Activities { get; set; }
        public DateTime ETA { get; set; }
        public List<RoleCreateModel> Roles { get; set; }
        
    }
}