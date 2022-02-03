using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Omar.Balance.Data;

public class BalanceEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public BalanceEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BalanceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BalanceDbContext>()
            .Database
            .MigrateAsync();
    }
}
