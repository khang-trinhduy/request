using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class TransitionExportModel
    {
        public int ProcessID { get; set; }
        public int CurrentStateID { get; set; }
        public int NextStateID { get; set; }
    }
}
