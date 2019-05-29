using System.Collections.Generic;

namespace Request.API.Models
{
    public class TriggerConf
    {
        public string Name { get; set; }
        public List<TriggerEvent> Event { get; set; }
        public List<TriggerAction> Action { get; set; }
        public List<TriggerTarget> Target { get; set; }

        public class TriggerEvent
        {
            public string Name { get; set; }
        }

        public class TriggerAction
        {
            public string Name { get; set; }
        }
        public class TriggerTarget
        {
            public string Name { get; set; }
            public List<TargetCondition> Condition { get; set; }

            public class TargetCondition
            {
                public string Param { get; set; }
                public string Type { get; set; }
                public List<TriggerOperator> Operator { get; set; }
                public class TriggerOperator
                {
                    public string Name { get; set; }
                }
            }
        }
        
    }
}