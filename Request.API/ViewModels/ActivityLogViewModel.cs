namespace Request.API.ViewModels.ActivityLogViewModel
{
    public class ActivityLogViewModel
    {
        public string User { get; set; }
        // public Activity Activity { get; set; }
        public bool IsCompleted { get; set; }
        // [Required]
        // public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}