namespace BestMovies.Pages.util;

public class PasswordHashing
{
   
    public static string HashString(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }

        // Uses SHA256 to create the hash
        using (var sha = new System.Security.Cryptography.SHA256Managed())
        {
            // Convert the string to a byte array first, to be processed
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + ConfigVariables.HashSalt);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            // Convert back to a string, removing the '-' that BitConverter adds
            string hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", string.Empty);

            return hash;
        }
    }
}