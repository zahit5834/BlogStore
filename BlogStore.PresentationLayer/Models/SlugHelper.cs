namespace BlogStore.PresentationLayer.Models
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            string slug = title.ToLower()
                .Replace(" ", "-")
                .Replace("ç", "c")
                .Replace("ş", "s")
                .Replace("ı", "i")
                .Replace("ğ", "g")
                .Replace("ü", "u")
                .Replace("ö", "o");

            return slug;
        }
    }
}
