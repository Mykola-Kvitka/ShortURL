namespace ShortURL.Api.Models
{
    public class URLViewModel : BaseModel
    {
        public string ShortURL { get; set; }
        public string OriginalURL { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CountOfRedirect { get; set; }
    }
}
