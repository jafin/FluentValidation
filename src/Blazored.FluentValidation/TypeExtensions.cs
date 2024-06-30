using System.Collections.Concurrent;

namespace Blazored.FluentValidation;

/// <summary>
/// Provides extension methods for the Type class.
/// </summary>
public static class TypeExtensions
{
    private static readonly ConcurrentDictionary<Type, bool> IsSimpleTypeCache = new();

    /// <summary>
    /// Determines if a given Type is considered a simple type.
    /// </summary>
    /// <param name="type">The Type to check.</param>
    /// <returns>
    /// True if the Type is a simple type; otherwise, false.
    /// Simple types are considered to be primitives, enums, string, decimal, DateTime, DateOnly, TimeOnly, DateTimeOffset, TimeSpan, Guid, or a nullable version of these types.
    /// </returns>
    public static bool IsSimpleType(this Type type)
    {
        return IsSimpleTypeCache.GetOrAdd(type, _ =>
            type.IsPrimitive ||
            type.IsEnum ||
            type == typeof(string) ||
            type == typeof(decimal) ||
            type == typeof(DateTime) ||
            type == typeof(DateOnly) ||
            type == typeof(TimeOnly) ||
            type == typeof(DateTimeOffset) ||
            type == typeof(TimeSpan) ||
            type == typeof(Guid) ||
            IsNullableSimpleType(type));

        static bool IsNullableSimpleType(Type t)
        {
            var underlyingType = Nullable.GetUnderlyingType(t);
            return underlyingType != null && IsSimpleType(underlyingType);
        }
    }
}