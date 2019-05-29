using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Models
{
    public class Group : AggregateRoot
    {
        public string Name { get; set; }
        public int ProcessID { get; set; }
    }
}
