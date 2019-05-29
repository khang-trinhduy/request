using Dms.API.Models;
using Identity.API.Models;
using Request.API.Model;
using SharedKernel.Abstractions;
using SharedKernel.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request.API.Models
{
    public class Flow
    {
        public int RequestID { get; set; }
        public int ProcessID { get; set; }
        public ICollection<string> Transitions { get; set; }
        public string CurrentState { get; set; }
        public string StartState { get; set; }
        public string EndState { get; set; }


    }
}
