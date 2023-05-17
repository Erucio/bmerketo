namespace ASP_Assignment.Models.Identity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
        public string CommentText { get; set; } = null!;
        public bool RememberMe { get; set; }
        public DateTime DateTime { get; set; }
    }
}
