namespace Shop.Common.Dtos;

public class AddCommentDto
{
    public string ProductId { get; set; }
    public string CommentText { get; set; }
    public int Note { get; set; }
}