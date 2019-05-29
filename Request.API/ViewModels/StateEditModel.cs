using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class StateEditModel
    {
        public int Id { get; set; }
        public int StateTypeID { get; set; }
        public int ProcessID { get; set; }
        public string Name { get; set; }
        public DateTime ETA { get; set; }
        public string Description { get; set; }
    }
}
