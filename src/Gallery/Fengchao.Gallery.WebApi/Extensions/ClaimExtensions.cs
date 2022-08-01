using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Fengchao.Gallery.WebApi.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="Claim"/>.
    /// </summary>
    public static class ClaimExtensions
    {
        /// <summary>
        /// Gets claim value by the given cliam type.
        /// </summary>
        /// <param name="claims"><see cref="Claim"/> collection.</param>
        /// <param name="claimType">Claim type name to find.</param>
        /// <returns>Claim value of the given type.</returns>
        public static string? GetClaimValue(this IEnumerable<Claim> claims, string claimType)
        {
            foreach (var claim in claims)
            {
                if (string.Equals(claimType, claim.Type, StringComparison.Ordinal))
                {
                    return claim.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets claim value by the given cliam type and converts the value to the specified type.
        /// </summary>
        /// <typeparam name="T">Type of claim value.</typeparam>
        /// <param name="claims"><see cref="Claim"/> collection.</param>
        /// <param name="claimType">Claim type name to find.</param>
        /// <param name="valueFactory">Represents a method for converting the found claim value to the given type.</param>
        /// <returns>Claim value of the given type.</returns>
        public static T GetClaimValue<T>(this IEnumerable<Claim> claims, string claimType, Func<string?, T> valueFactory)
        {
            foreach (var claim in claims)
            {
                if (string.Equals(claimType, claim.Type, StringComparison.Ordinal))
                {
                    return valueFactory(claim.Value);
                }
            }

            return default!;
        }
    }
}
