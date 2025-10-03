using SPSS.BusinessObject.Dtos.BlogSection;

namespace SPSS.BusinessObject.Dtos.Blog;

public class BlogWithDetailDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Thumbnail { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
    public List<BlogSectionDto> Sections { get; set; }
}
