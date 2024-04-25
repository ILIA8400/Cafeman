using System.ComponentModel.DataAnnotations.Schema;

namespace CafeMan_Project.Models.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentByName { get; set; }
        public string CommentText { get; set; }
        public double Star { get; set; }
        public DateTime Date { get; set; }
        public int? Likes { get; set; }
        public string? Images { get; set; }
        public Cafe Cafe { get; set; }
        public int CafeId { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
