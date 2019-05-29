using Request.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Request.API.Model
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string User { get; set; }
        public Activity Activity { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}