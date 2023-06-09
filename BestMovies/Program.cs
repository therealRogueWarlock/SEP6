using BestMovies.DataAccess;
using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.DataAccess.RestApiDataAccess;
using BestMovies.Services;
using BestMovies.Services.implementation;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

// data
builder.Services.AddScoped<IRestApiDataAccess, RestApiDataAccess>();
builder.Services.AddScoped<IDataBaseAccess, DataBaseAccess>();
builder.Services.AddScoped<IPeopleDao, PeopleRestApiDao>();
builder.Services.AddScoped<IMovieDao, MovieRestApiDao>();
builder.Services.AddScoped<IFanMovieDao, FanMovieDao>();
builder.Services.AddScoped<ICommentDao, CommentDao>();
builder.Services.AddScoped<IReviewDao, ReviewDao>();
builder.Services.AddScoped<IFavoriteDao, FavoriteDao>();
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IApiDao, ApiDao>();

// services
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUserInteractionService, UserInteractionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

// login service
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("SecurityLevel1", a => a.RequireClaim("Level", "1", "2"));
  options.AddPolicy("SecurityLevel2", a => a.RequireClaim("Level", "2")); 
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();