using System.Collections.Generic;
using Request.API.Models;

namespace Request.API.ViewModels
{
    public class SubmitActionViewModel
    {
        public string source { get; set; }
        public string role { get; set; }
        public string action { get; set; }
        public string activity { get; set; }
        public string approver { get; set; }
        public List<DataCreateModel> data { get; set; }
        public bool doactivity { get; set; }
        public SubmitActionViewModel(string source, string role, string action, string activity, List<DataCreateModel> data, bool doactivity = true)
        {
            this.source = source;
            this.role = role;
            this.action = action;
            this.activity = activity;
            this.data = data;
            this.doactivity = doactivity;
        }
        public SubmitActionViewModel()
        {
        }

    }
}