using Request.API.Models;
using Request.API.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class ActivityViewModel
    {
        public int Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsRequired { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public string AbsentName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public string ApproverName { get; set; }
        public string FullName { get; set; }
        public string CampainName { get; set; }
        public bool IsRunning { get; set; }
        public List<ContactViewModel> Subscribers { get; set; }
        public string Discriminator { get; set; }
    }
}
