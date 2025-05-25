using Microsoft.EntityFrameworkCore;
using Rommanel.Infra.Context;

namespace Rommanel.Api.Services;

public class DatabaseManagementService
{
    public static void MigrateDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
        if (dbContext != null)
        {
            dbContext.Database.Migrate();
        }
    }
}
