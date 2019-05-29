using Request.API.Model;
using Request.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace Request.API.ViewModels
{
    public class RequestCreateModel
    {

        public ProcessCreateModel Process { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }   
        public List<DataCreateModel> Data { get; set; }
    }
}
