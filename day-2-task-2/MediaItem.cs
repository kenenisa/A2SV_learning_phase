public class MediaItem
{
    public MediaItem(string Title, string MediaType, int Duration)
    {
        this.Title = Title;
        this.MediaType = MediaType;
        this.Duration = Duration;
    }
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }
}