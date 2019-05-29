using MimeKit;
using Request.API.Model;
using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Models
{
    [Table("Data")]
    public class Email : Data
    {
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

        public override DataType GetDataType()
        {
            return DataType.Email;
        }

        public Email()
        { }

        public Email(DataType dataType, Model.Request request, string from, string to, string subject, string contents, byte[] attach, string server, string confirmEmail, string confirmPass, bool isSent, string client)
        {
            DataType = dataType;
            Request = request;
            From = from;
            To = to;
            Subject = subject;
            Contents = contents;
            Attach = attach;
            Server = server;
            ConfirmEmail = confirmEmail;
            ConfirmPass = confirmPass;
            IsSent = isSent;
            Client = client;
        }
    }

    [Table("Data")]
    public class Comment : Data
    {
        public string Messages { get; set; }
        public byte[] Emoji { get; set; }
        public string Topic { get; set; }

        public Comment() {  }

        public override DataType GetDataType()
        {
            return DataType.Comment;
        }
    }
    [Table("Data")]
    public class TLeave : Data
    {
        public string AbsentName { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public bool IsDone { get; set; }
        public string ApproverName { get; set; }

        public TLeave() {  }

        public override DataType GetDataType()
        {
            return DataType.TalentLeave;
        }
    }

    [Table("Data")]
    public class Contact : Data
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public override DataType GetDataType()
        {
            return DataType.Contact;
        }
    }

    [Table("Data")]
    public class Campaign : Data
    {
        public string CampaignName { get; set; }
        public bool IsRunning { get; set; }
        public List<Contact> Subscribers { get; set; }
        public override DataType GetDataType()
        {
            return DataType.Campaign;
        }
        public Campaign () {
            Subscribers = new List<Contact>();
        }
    }
}
