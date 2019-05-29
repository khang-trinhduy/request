using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class GetActionViewModel
    {
        public string Name { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public string ActivityName { get; set; }
        public string TargetName { get; set; }
        //group | user ?
    }
}
