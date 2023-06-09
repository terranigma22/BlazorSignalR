namespace BlazorSignalR.Client.Utilities
{
    public class ImageUtilities
    {
        static public string GetImage(string name)
        {
            return $"images/{name}";
        }
    }
}
