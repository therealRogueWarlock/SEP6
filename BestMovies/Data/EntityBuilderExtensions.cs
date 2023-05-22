using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestMovies.Data;

public static class EntityBuilderExtensions
{
    public static ReferenceCollectionBuilder IsOptional(this ReferenceCollectionBuilder builder)
    {
        return builder.IsRequired(false);
    }
}