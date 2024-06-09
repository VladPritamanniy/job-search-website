using JobSearch.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.WEB.HelperExtensions
{
    public static class DatabaseExtensionHelper
    {
        public static async Task MigrateDatabaseAsync(this IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<JobSearchContext>();
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating/migrating database.");

                    throw;
                }
            }
        }
    }
}
