using BestMovies.DataAccess;
using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BestMovies.Data.CustomServices
{
    public class LoginService : ILoginService
    {
        
        private readonly IUserData _userData;

        public LoginService(IUserData userData)
        {
            _userData = userData;
        }
        
        public Task<User?> Validate(string username, string password)
        {
            return _userData.GetUser(username,HashString(password,"sep6"));
        }
        
        static string HashString(string text, string salt = "")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }
    
            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);
        
                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
        
    }
    
}


