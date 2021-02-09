namespace WikimediaData.Entities
{
    public class PageViewEntry
    {
        public string DomainCode { get; set; }
        public string PageTitle { get; set; }
        public uint ViewCount { get; set; } //max value 4200M
    }
}
