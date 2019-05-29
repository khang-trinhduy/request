using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public class Action
    {

        //public int ActionTypeID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Node Node { get; set; }
        public int ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public Process Process { get; set; }

        public Action() { }

        private Action(string name, string description)
        {
            //ActionTypeID = actionTypeID;
            //ProcessID = processID;
            Name = name;
            Description = description;
        }

        public static Action Create(string name, string description) {
            return new Action( name, description);
        }
    }
}
