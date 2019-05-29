using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System;

namespace Request.API.Models
{
    public class Trigger
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsNotActive { get; set; }
        public int Position { get; set; }
        public string Descriptions { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<AutoAction> AutoActions { get; set; }
    }
}