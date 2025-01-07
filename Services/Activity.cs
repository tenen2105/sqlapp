namespace sqlapp.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string? OperationName { get; set; }
        public string? Status { get; set; }
        public string? EventCategory { get; set; }
        public string? ResourceType { get; set; }
        public string? Resource { get; set; }
    }
}
