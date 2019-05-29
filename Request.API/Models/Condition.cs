namespace Request.API.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}