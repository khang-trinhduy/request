using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Request.API.Model;
using SharedKernel.Abstractions;
using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public abstract class Activity
    {
        public int Id { get; set; }
        public ActivityType ActivityType { get; set; }
        [ForeignKey("ProcessId")]
        public Process Process { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsRequired { get; set; }
        public List<Role> Roles { get; set; }
        public State State { get; set; }
        public int ProcessId { get; set; }
        public string Discriminator { get; set; }
        public List<Data> Data { get; set; }
        public Node Node { get; set; }
        public abstract void DoActivityThings(Data data);
    }

    public enum ActivityType
    {
        Email = 0,
        Call = 1,
        Upload = 2,
        Generic = 3,
        Absent = 4,
        Campaign = 6,
        Contact = 5
    }

    [Table("Activities")]
    public class ActivityAdapter : Activity
    {
        public ExtendActivity ExtendActivity { get; set; }

        public override void DoActivityThings(Data data)
        {
            if (data.DataType == Model.DataType.Email)
            {
                ExtendActivity = new EmailSender();
                ExtendActivity.SendEmail(data);
            }
            else if (data.DataType == Model.DataType.Comment)
            {
                //Data.Add(data);
            }
        }
    }

    [Table("Activities")]
    public class TLActivityOperator : Activity
    {
        public TLActivityOperator() { }
        public string AbsentName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        // public bool IsDone { get; set; }
        public string ApproverName { get; set; }
        public ActivityAdapter Adapter { get; set; }

        public override void DoActivityThings(Data data)
        {
            if (data.GetDataType() == Model.DataType.Comment)
            {
                Adapter = new ActivityAdapter();
                Adapter.DoActivityThings(data);
            }
        }
    }

    [Table("Activities")]
    public class CampaignActivityOperator : Activity
    {
        public string CampaignName { get; set; }
        public bool IsRunning { get; set; }
        public List<Contact> Subscribers { get; set; }
        public ActivityAdapter Adapter { get; set; }

        public override void DoActivityThings(Data data)
        {
            if (data.GetDataType() == Model.DataType.Campaign)
            {
                Adapter = new ActivityAdapter();
                Adapter.DoActivityThings(data);
            }
        }
    }

    [Table("Activities")]
    public class EmailActivityOperator : Activity
    {
        public EmailActivityOperator() { }
        public ActivityAdapter Adapter { get; set; }

        public override void DoActivityThings(Data data)
        {
            if (data.GetDataType() == Model.DataType.Email)
            {
                Adapter = new ActivityAdapter();
                Adapter.DoActivityThings(data);
            }
            else if (data.GetDataType() == Model.DataType.Others)
            {
                
            }
        }
    }

    [Table("Activities")]
    public class GenericActivityOperator : Activity
    {
        public GenericActivityOperator() { }

        public ActivityAdapter Adapter { get; set; }

        public override void DoActivityThings(Data data)
        {
        }
    }

    public abstract class ExtendActivity
    {
        public int Id { get; set; }
        public abstract void SendEmail(Data data);

    }

    public class EmailSender : ExtendActivity
    {
        public override async void SendEmail(Data data)
        {
            var client = new HttpClient();
            var uri = new Uri(((Email)data).Client);
            var contents = new StringContent(JsonConvert.SerializeObject((Email)data), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, contents);
            if (!!result.IsSuccessStatusCode)
            {
                return;
            }
            throw new InvalidOperationException(result.Content.ToString());
        }
        public void SendBusinessEmail()
        {
        }
    }
    public class ActivityConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Activity);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(EmailActivityOperator));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public class DataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(Email));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
