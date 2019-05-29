using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public class TransitionRule : ExtendRule
    {

        public int Id { get; set; }
        public State CurrentState { get; set; }
        public State NextState { get; set; }
        public Action Action { get; set; }
        public Process Process { get; set; }
        public int ProcessId { get; set; }
        public TransitionRule() : base() { }

        private TransitionRule(State currentstate, State nextstate, Action action, Process process, Node currentnode, Node nextnode)
        {
            CurrentNode = currentnode;
            NextNode = nextnode;
            CurrentState = currentstate;
            NextState = nextstate;
            Process = process;
            Action = action;
        }

    }
}
