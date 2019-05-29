using SharedKernel.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Request.API.Infrastructure
{
    public class RequestExportModel
    {
        public int ProcessID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int CurrentStateID { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateRequested { get; set; }
    }
}