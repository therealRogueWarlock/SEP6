using BestMovies.DataAccess;
using BestMovies.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BestMovies.Data.CustomServices
{
    public class LoginService : ILoginService
    {
        
        private readonly IUserDataAccess _userDataAccess;

        public LoginService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        
        public Task<User>? Validate(string username, string password)
        {
            return _userDataAccess.GetUser(username,HashString(password,"sep6"));
        }

        public Task RegisterUser(User newUser)
        {
            throw new NotImplementedException();
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
    
    public interface IUserDataAccess
    {
        public Task<User> GetUser(string username,string password);
    }

    public class UserDummyDataAccess : IUserDataAccess
    {
        
        public Task<User> GetUser(string username, string password)
        {

            if (username.Equals("admin") &&
                password.Equals("29899A81012B8AC0815232E9452CE0A37F5D0CC72D9556AA09F1EF7619C2100D"))
                return Task.FromResult(new User { Username = username, PasswordHash = password, SecurityLevel = 2 });
            
            return null;
        }
        
    }


}


