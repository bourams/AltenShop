using Api.Common;
using NSubstitute;

namespace Api.UnitTests.Helpers;

internal static class DateTimeProviderHelper
{
    public static IDateTimeProvider GetProvider(DateTime date)
    {
        var dateTimeProvider = Substitute.For<IDateTimeProvider>();
        dateTimeProvider.UtcNow.Returns(date);

        return dateTimeProvider;
    }
}
