using Newtonsoft.Json;
using Request.API.ViewModels;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public class Process : AggregateRoot
    {

        public string Name { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<TransitionRule> Rules { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Node> Nodes {get; set;}
        public Process(string name) : base()
        {
            Actions = new List<Action>();
            States = new List<State>();
            Rules = new List<TransitionRule>();
            Roles = new List<Role>();
            Activities = new List<Activity>();
            Nodes = new List<Node>();
        }

        public Process()
        {
            
        }

        public Process(string name, ICollection<Action> actions, ICollection<State> states, ICollection<TransitionRule> rules)
        {
            Name = name;
            Actions = actions;
            States = states;
            Rules = rules != null ? rules : new List<TransitionRule>();
            Roles = new List<Role>();
            Activities = new List<Activity>();
        }

        public Process(string name, ICollection<Action> actions, ICollection<State> states, ICollection<TransitionRule> rules, ICollection<Role> roles)
        {
            Name = name;
            Actions = actions;
            States = states;
            Rules = rules != null ? rules : new List<TransitionRule>();
            Roles = roles != null ? roles : new List<Role>();
        }

        public Process(string name, ICollection<Action> actions, ICollection<State> states, ICollection<TransitionRule> rules, ICollection<Role> roles, ICollection<Activity> activities)
        {
            Name = name;
            Actions = actions;
            States = states;
            Rules = rules != null ? rules : new List<TransitionRule>();
            Roles = roles != null ? roles : new List<Role>();
            Activities = activities != null ? activities : new List<Activity>();
        }

        public List<Activity> GetActivities(State state)
        {
            List<Activity> activities = new List<Activity>();
            foreach (var item in state.Activities)
            {
                var activity = Activities.FirstOrDefault(e => e.Name == item.Name);
                if (activity != null)
                {
                    activities.Add(activity);
                }
            }
            if (activities.Count < 0)
            {
                throw new Exception($"cannot find any activity");
            }
            return activities;
        }

        public string SendEmail(List<string> emails) {
            return $"send email to $(email.Count) email";
        }

        public string Gift(List<Contact> data) {
            string str = "";
            foreach (var c in data)
            {
                if (c.Age > 18)
                {
                    str += "send gift to " + c.FullName;
                    
                }
            }
            return str;
        }

        public State TransitFrom(string source, string action, string role)
        {
            var rule = Rules.FirstOrDefault(e => e.CurrentState.Name == source && e.Action.Name == action);
            if (rule is null)
            {
                throw new InvalidOperationException(nameof(action));

            }
                        
            var tempstate = States.FirstOrDefault(e => e.Name == rule.NextState.Name);
            if (tempstate is null)
            {
                throw new NullReferenceException(nameof(tempstate));
            }
            var state = States.FirstOrDefault(e => e.Name == rule.CurrentState.Name);
            var r = state.Roles.FirstOrDefault(e => e.Name == role);
            if (r is null)
            {
                throw new Exception($"you don't have permission to make this change {source} {role}");
            }
            return States.FirstOrDefault(e => e.Name == rule.NextState.Name);
        }

        public State TransitFrom(string source)
        {
            var rule = Rules.FirstOrDefault(e => e.CurrentState.Name == source);
            if (rule is null)
            {
                throw new InvalidOperationException("is request completed?");

            }
            return States.FirstOrDefault(e => e.Name == rule.NextState.Name);
        }

        public List<Action> GetAvailableActions(string currentState)
        {
            return Rules.Where(e => e.CurrentState.Name == currentState).Select(e => new Action { Name = e.Action.Name }).ToList();
        }

        public List<Activity> NodeGetActivities(Node node)
        {
            List<Activity> activities = new List<Activity>();
            foreach (var item in node.Activities)
            {
                var activity = Activities.FirstOrDefault(e => e.Name == item.Name);
                if (activity != null)
                {
                    activities.Add(activity);
                }
            }
            if (activities.Count < 0)
            {
                throw new Exception($"cannot find any activity");
            }
            return activities;
        }

        public Node NodeTransitFrom(string source, string action, string role)
        {
            var rule = Rules.FirstOrDefault(e => e.CurrentNode.Name == source && e.Action.Name == action);
            var node = Nodes.FirstOrDefault(n => n.Actions.FirstOrDefault(a => a.Name.Equals(action)) != null && n.Name.Equals(source));
            if (node is null) {
                throw new NullReferenceException($"cannot find node with name {source} that have action {action}");
            }
            if (rule is null)
            {
                throw new InvalidOperationException(nameof(action));

            }
            var tempstate = Nodes.FirstOrDefault(e => e.Name == rule.NextNode.Name);
            if (tempstate is null)
            {
                throw new NullReferenceException(nameof(tempstate));
            }
            var r = node.Roles.FirstOrDefault(e => e.Name == role);
            if (r is null)
            {
                throw new Exception($"you don't have permission to make this change {source} {role}");
            }
            if (node.IsLeaf()) {
                throw new Exception($"cannot find any path. Is it completed?");
            }
            return node.Move(node.Childs.FirstOrDefault(e => e.Name == rule.NextNode.Name).Name);
        }

        public Node NodeTransitFrom(string source)
        {
            var rule = Rules.FirstOrDefault(e => e.CurrentNode.Name == source);
            if (rule is null)
            {
                throw new InvalidOperationException("is request completed?");

            }
            var node = Nodes.FirstOrDefault(n => n.Name == source);
            if (node is null) {
                throw new NullReferenceException(nameof(Node));
            }
            if (node.IsLeaf()) {
                throw new Exception($"cannot find any path. Is it completed?");
            }
            return node.Move(node.Childs.FirstOrDefault(e => e.Name == rule.NextNode.Name).Name);
        }

        public List<Action> NodeGetAvailableActions(string currentNode)
        {
            return Rules.Where(e => e.CurrentNode.Name == currentNode).Select(e => new Action { Name = e.Action.Name }).ToList();
        }
    }
    public class ExtendRule
    {
        public Node CurrentNode { get; set; }
        public Node NextNode { get; set; }
        public ExtendRule() { }
    }

    public class TransitionRuleViewModel
    {
        public int Id { get; set; }
        public StateViewModelSimplified CurrentState { get; set; }
        public StateViewModelSimplified NextState { get; set; }
        public NodeViewModelSimplified CurrentNode { get; set; }
        public NodeViewModelSimplified NextNode { get; set; }
        public ActionViewModel Action { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        public Node Node { get; set; }
        public int? StateId { get; set; }
    }
}
