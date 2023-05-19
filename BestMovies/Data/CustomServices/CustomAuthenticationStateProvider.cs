using System.Security.Claims;
using System.Text.Json;
using BestMovies.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BestMovies.Data.CustomServices
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserService _userService;
        private AuthenticationState? _cachedAuthenticationState;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService)
        {
            _jsRuntime = jsRuntime;
            _userService = userService;
            _cachedAuthenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState?> GetAuthenticationStateAsync()
        {
            
            string userAsJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "currentUser");

            if (!string.IsNullOrEmpty(userAsJson))
            {
                User tmp = JsonSerializer.Deserialize<User>(userAsJson);
                await ValidateLogin(tmp.Username, tmp.PasswordHash);
            }
            
            return await Task.FromResult(_cachedAuthenticationState);
            
        }

        public async Task ValidateLogin(string username, string password)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                User user = await _userService.Validate(username, password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", serialisedData);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            _cachedAuthenticationState = new AuthenticationState(new ClaimsPrincipal(identity));
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthenticationState));
        }

        public void Logout()
        {
            _cachedAuthenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthenticationState));
        }

        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            claims.Add(new Claim("Level", user.SecurityLevel.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}