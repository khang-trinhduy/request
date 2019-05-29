using Request.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class StateViewModel
    {
        public int Id { get; set; }
        public StateType StateType { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        //[JsonConverter(typeof(ActivityJsonConverter))]
        public List<ActivityViewModel> Activities { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public int ProcessId { get; set; }
        public DateTime ETA { get; set; }
    }
}
