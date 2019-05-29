using System.ComponentModel.DataAnnotations.Schema;
using Request.API.Model;

namespace Request.API.Models
{
    public abstract class Data
    {
        public int Id { get; set; }
        public DataType DataType { get; set; }
        public Request.API.Model.Request Request { get; set; }
        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public virtual Activity Activity { get; set; }
        public abstract DataType GetDataType();
    }

}