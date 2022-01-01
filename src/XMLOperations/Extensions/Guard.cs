namespace XMLOperations.Extensions
{
    internal static class Guard
    {
        internal static bool AgainstNullOrWhiteSpace(string? value) => string.IsNullOrWhiteSpace(value);
        internal static bool AgainstNull(object? value) => value != null;
    }
}
