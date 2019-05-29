using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public class RequestAction
    {
        public int Id { get; set; }
        public int RequestID { get; set; }
        public int ActionID { get; set; }
        public int TransitionID { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
    }
}
