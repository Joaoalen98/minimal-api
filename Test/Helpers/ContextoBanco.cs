using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;

namespace Test.Helpers;

public static class ContextoBanco
{
    public static DbContexto CriarContextoDeTeste()
    {
        var context = new DbContexto(ConfigurationHelper.GetConfiguration());
        var pendingMigrations = context.Database.GetPendingMigrations();

        if (pendingMigrations.Any())
            context.Database.Migrate();

        return context;
    }
}
