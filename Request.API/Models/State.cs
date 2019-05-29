using Newtonsoft.Json;
using SharedKernel.Abstractions;
using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public class State : AggregateRoot
    {
        public StateType StateType { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Role> Roles { get; set; }
        [ForeignKey("ProcessId")]
        public Process Process { get; set; }
        public int? ProcessId { get; set; }
        public DateTime ETA { get; set; }

        public State() : base() { }

        private State(StateType stateTypeID, int processId, string name, string description, List<Activity> activities, List<Role> roles, DateTime eta)
        {
            StateType = stateTypeID;
            ProcessId = processId;
            Name = name;
            Description = description;
            Activities = activities;
            Roles = roles;
            ETA = eta;
        }

        public static State Create(StateType stateTypeID, int processID, string name, string description, List<Activity> activities, List<Role> roles, DateTime eta)
        {
            return new State(stateTypeID, processID, name, description, activities, roles, eta);
        }
    }

    public enum StateType
    {
        start = 0,
        end = 1,
        normal = 2
    }
}
