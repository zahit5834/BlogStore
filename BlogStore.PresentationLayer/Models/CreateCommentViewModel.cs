using System.Text.Json.Serialization;

namespace BlogStore.PresentationLayer.Models
{
    public class CreateCommentViewModel
    {
        [JsonPropertyName("commentDetail")]
        public string CommentDetail { get; set; }
        [JsonPropertyName("articleId")]
        public int ArticleId { get; set; }
    }
}
