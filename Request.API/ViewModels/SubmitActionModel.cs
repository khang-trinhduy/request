using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class SubmitActionModel
    {
        public int RequestID { get; set; }
        public string Action { get; set; }
        public string Activity { get; set; }
        public string State { get; set; }
        public int UserID { get; set; }
    }
}
