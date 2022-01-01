using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLOperations.Types;

namespace XMLOperations.Extensions
{
    internal static class Guard
    {
        public static bool AgainstEmpty(string? value) => string.IsNullOrWhiteSpace(value);
        internal static bool AgainstNull(object? value) => value != null;
    }
}
