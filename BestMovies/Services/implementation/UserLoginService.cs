using System.Text.Json;
using BestMovies.DataAccess;
using BestMovies.Models.DbModels;
using Microsoft.Extensions.ObjectPool;
using Microsoft.JSInterop;

namespace BestMovies.Services.implementation
{
    public class UserLoginService : IUserLoginService
    {
        
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserDao _userDao;
        private User? _currentUser;
        public bool IsLoggedIn
        {
            get;
            private set;
        }

        public UserLoginService(IJSRuntime jsRuntime, IUserDao userDao)
        {
            _userDao = userDao;
            _jsRuntime = jsRuntime;
        }
        
        // "Validate"
        public async Task<User?> Validate(string username, string password)
        {
            _currentUser = await _userDao.GetUserAsync(username, password);
            await CacheUser(_currentUser);
            return _currentUser;
        }

        public async Task RegisterUser(User newUser)
        {
            await _userDao.AddAsync(newUser);
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
                IsLoggedIn = true;
            }
            
            return _currentUser;
        }

        private async Task CacheUser(User? user)
        {
            if (user != null) IsLoggedIn = true;
            string serialisedData = JsonSerializer.Serialize(user);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", serialisedData);
        }

        public void ClearCachedUser()
        {
            _currentUser = null;
            IsLoggedIn = false;
            _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", "");
        }
    }
}


