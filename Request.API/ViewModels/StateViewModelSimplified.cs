using Request.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.ViewModels
{
    public class StateViewModelSimplified
    {
        public int Id { get; set; }
        public StateType StateType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
    public class NodeViewModelSimplified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
    }
