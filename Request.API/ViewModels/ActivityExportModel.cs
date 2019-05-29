using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class ActivityExportModel
    {
        public int ActivityTypeID { get; set; }
        public int ProcessID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
