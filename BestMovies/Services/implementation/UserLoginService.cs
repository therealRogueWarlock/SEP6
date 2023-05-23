using System.Text.Json;
using BestMovies.DataAccess;
using BestMovies.Models.DbModels;
using Microsoft.JSInterop;

namespace BestMovies.Services.implementation
{
    public class UserLoginService : IUserLoginService
    {
        
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserDao _userDao;
        private User? _currentUser;

        public UserLoginService(IJSRuntime jsRuntime, IUserDao userDao)
        {
            _userDao = userDao;
            _jsRuntime = jsRuntime;
        }
        
        public async Task<User?> Validate(string username, string password)
        {
            _currentUser = await _userDao.GetUser(username, password);
            await CashUser(_currentUser);
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


