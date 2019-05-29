using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Request.API.Model;
using Request.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Request.API.ViewModel
{
    public class RequestEditModel
    {
        public int Id { get; set; }
        public int ProcessID { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CurrentStateID { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateRequested { get; set; }

    }
}