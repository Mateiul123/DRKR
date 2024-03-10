namespace DRKR.Models
{
    public class Text : Media
    {
        public string Content { get; set; }

        // TextContent-specific implementation of DisplayInfo. Duration is not applicable.
        public override string DisplayInfo() => $"Text Title: {Title}, Content Length: {Content.Length} characters";
    }
}
