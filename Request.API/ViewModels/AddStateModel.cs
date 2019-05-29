using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class AddStateModel
    {
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public string ActionDescription { get; set; }
        public int StateTypeID { get; set; }
        public string Approve { get; set; }
        public string Deny { get; set; }
        public string Resolve { get; set; }
        public string Cancel { get; set; }
        public string Restart { get; set; }
    }
}
