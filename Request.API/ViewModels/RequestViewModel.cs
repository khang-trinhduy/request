using Request.API.Model;
using Request.API.Models;
using Request.API.ViewModels;
using Request.API.ViewModels.ActivityLogViewModel;
using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModel
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public ProcessViewModel Process { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public StateViewModelSimplified CurrentState { get; set; }
        public NodeViewModelSimplified CurrentNode { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateRequested { get; set; }
        public List<ActivityLogViewModel> Histories { get; set; }
        public ICollection<TaskViewModel> Tasks { get; set; }
        public List<DataViewModel> Data { get; set; }
    }

    public class DataViewModel
    {
        // public ActivityViewModel Activity { get; set; }
        public Model.DataType DataType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Contents { get; set; }
        public byte[] Attach { get; set; }
        public string Server { get; set; }
        public string ConfirmEmail { get; set; }
        public string ConfirmPass { get; set; }
        public bool IsSent { get; set; }
        public string Client { get; set; }
         public string AbsentName { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public bool IsDone { get; set; }
        public string ApproverName { get; set; }
        public string Messages { get; set; }
        public byte[] Emoji { get; set; }
        public string Topic { get; set; }
        public string CampaignName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool IsRunning  { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<ContactViewModel> Subscribers { get; set; }

        // public string Discriminator { get; set; }
    }

    public class ContactViewModel
    {
         public string FullName { get; set; }
         public int Age { get; set; }
         public string Email { get; set; }
         public string PhoneNumber { get; set; }
    }

    public class TaskViewModel
    {
        public int Id { get; set; }
        public ActivityViewModel Activity { get; set; }
        public bool IsDone { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public string UserRole { get; set; }
    }
}
