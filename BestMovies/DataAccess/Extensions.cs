namespace BestMovies.DataAccess;

public static class Extensions
{
    public static Func<TType, string, bool> Search<TType>(params Func<TType, object>[] selectors)
    {
        return (obj, str) => str.Split(" ")
            .All(s => selectors.Any(sel =>
                sel(obj).ToString()?.ToLower().Contains(s.ToLower()) ?? false));
    }
}