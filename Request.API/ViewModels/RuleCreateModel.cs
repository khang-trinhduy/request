using System.Collections.Generic;
using Request.API.Models;

namespace Request.API.ViewModels
{
    public class RuleCreateModel
    {
        public StateCreateModel CurrentState { get; set; }
        public StateCreateModel NextState { get; set; }
        public NodeCreateModel CurrentNode { get; set; }
        public NodeCreateModel NextNode { get; set; }
        public ActionCreateModel Action { get; set; }
    }

}