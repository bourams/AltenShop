﻿namespace Api.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
