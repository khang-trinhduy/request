using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Request.API.Model;
using Request.API.Models;
using Request.API.ViewModel;

namespace Request.API.ViewModels
{
    public class ActivityCreateModel
    {
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsRequired { get; set; }
        public List<RoleCreateModel> Roles { get; set; }
        public string Discriminator { get; set; }
        public List<Data> Data { get; set; }
        public string AbsentName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public string ApproverName { get; set; }
        public string CampaignName { get; set; }
        public bool IsRunning { get; set; }
        public List<ContactViewModel> Subscribers { get; set; }
    }
}