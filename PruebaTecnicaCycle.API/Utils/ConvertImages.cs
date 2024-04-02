namespace PruebaTecnicaCycle.API.Utils
{
    public class ConvertImages
    {
        public static string? ConvertImageToBase64(IFormFile imagePath)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    imagePath.CopyTo(memoryStream);

                    byte[] imageBytes = memoryStream.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);

                    return base64String;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error base64 converter: {ex.Message}");
                return null;
            }
        }
    }
}