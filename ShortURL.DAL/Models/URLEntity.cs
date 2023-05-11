namespace ShortURL.DAL.Models
{
    public class URLEntity : BaseModel
    {
        public string ShortURL { get; set; }
        public string OriginalURL { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CountOfRedirect { get; set; }

    }
}
