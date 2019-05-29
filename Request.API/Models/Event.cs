using System.Collections.Generic;

namespace Request.API.Models
{
    public class Event
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Condition> Conditions { get; set; }
    }
    
}