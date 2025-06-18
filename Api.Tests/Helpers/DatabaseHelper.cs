using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Helpers;

internal static class DatabaseHelper
{
    public static AppDbContext GetInMemoryDbContext()
    {
        var dbName = "TestDb_" + System.Guid.NewGuid();
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new AppDbContext(options);
    }
}