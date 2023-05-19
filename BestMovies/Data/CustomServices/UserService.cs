using System.Text.Json;
using BestMovies.DataAccess;
using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.JSInterop;

namespace BestMovies.Data.CustomServices
{
    public class UserService : IUserService
    {
        
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserData _userData;
        private User? _currentUser;

        public UserService(IJSRuntime jsRuntime, IUserData userData)
        {
            _userData = userData;
            _jsRuntime = jsRuntime;
        }
        
        public async Task<User?> Validate(string username, string password)
        {
            _currentUser = await _userData.GetUser(username, password);
            await CashUser(_currentUser);
            return _currentUser;
        }
        
        public async Task<User?> GetCurrentUserAsync()
        {
            return _currentUser ?? await GetCachedUser();
        }
        
        private async Task<User?> GetCachedUser()
        {
            
            string userAsJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "currentUser");

            if (!string.IsNullOrEmpty(userAsJson))
            {
                _currentUser = JsonSerializer.Deserialize<User>(userAsJson);
            }
            
            return _currentUser;
        }

        private async Task CashUser(User? user)
        {
            string serialisedData = JsonSerializer.Serialize(user);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", serialisedData);
        }

        public void ClearCashedUser()
        {
            _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", "");
        }
        
        
    }
    
}


