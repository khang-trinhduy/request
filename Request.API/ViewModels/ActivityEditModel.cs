using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class ActivityEditModel
    {
        public int Id { get; set; }
        public int ActivityTypeID { get; set; }
        public int ProcessID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
