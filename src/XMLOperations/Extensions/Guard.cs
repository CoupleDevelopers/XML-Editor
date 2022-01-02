using System.Runtime.CompilerServices;
using XMLOperations.Exceptions;

namespace XMLOperations.Extensions
{
    internal static class Guard
    {
        internal static void AgainstNullOrWhiteSpace
            (string? value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new GuardException($"{field} is empty");
        }

        internal static void AgainstNull(object? value, string field)
        {
            if(value == null)
                throw new GuardException($"{field} is null");
        }

        internal static void AgainstNullOrEmpty<T>(List<T>? value, string field)
        {
            if (value == null)
                throw new GuardException($"{field} is null");

            if (value.Count == 0)
                throw new GuardException($"{field} is empty");
        }
    }
}
