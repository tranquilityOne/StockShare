using System;

namespace Fengchao.Gallery.Core
{
    /// <summary>
    /// Provides extension methods for <see cref="DateTime"/> and related classes.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z 
        /// to a <see cref="DateTimeOffset"/> value.
        /// </summary>
        /// <param name="seconds">
        /// A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z 
        /// (January 1, 1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
        /// </param>
        /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
        public static DateTimeOffset ToDateTimeOffset(this long seconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds);
        }

        /// <summary>
        /// Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z 
        /// to a <see cref="DateTime"/> value that represents the local date and time.
        /// </summary>
        /// <param name="seconds">
        /// A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z 
        /// (January 1, 1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
        /// </param>
        /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
        public static DateTime ToLocalDateTime(this long seconds)
        {
            return seconds.ToDateTimeOffset().LocalDateTime;
        }

        /// <summary>
        /// Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z 
        /// to a <see cref="DateTime"/> value that represents the date and time of a specified offset.
        /// </summary>
        /// <param name="seconds">
        /// A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z 
        /// (January 1, 1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
        /// </param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
        public static DateTime ToDateTime(this long seconds, TimeSpan offset)
        {
            return seconds.ToDateTimeOffset().UtcDateTime.Add(offset);
        }

        /// <summary>
        /// Returns the number of seconds that have elapsed from 1970-01-01T00:00:00Z to the given 
        /// <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to calculate.</param>
        /// <returns>The number of seconds that have elapsed since 1970-01-01T00:00:00Z.</returns>
        public static long ToUnixTimeSeconds(this DateTime dateTime)
        {
            return dateTime.ToUnixTimeSeconds(dateTime.Kind);
        }

        /// <summary>
        /// Returns the number of seconds that have elapsed from 1970-01-01T00:00:00Z to the given 
        /// <see cref="DateTime"/> of specified <see cref="DateTimeKind"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to calculate.</param>
        /// <param name="kind">Overwrites <see cref="DateTimeKind"/> of the given <see cref="DateTime"/>.</param>
        /// <returns>Timestamp.</returns>
        public static long ToUnixTimeSeconds(this DateTime dateTime, DateTimeKind kind)
        {
            dateTime = DateTime.SpecifyKind(dateTime, kind);

            return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        }

        /// <summary>
        /// Gets the value of the current <see cref="TimeSpan"/> structure expressed in whole and fractional years.
        /// (Counts 365 days as a year)
        /// </summary>
        /// <param name="timeSpan"><see cref="TimeSpan"/> to convert.</param>
        /// <returns>The total number of days represented by this instance.</returns>
        public static double TotalYears(this TimeSpan timeSpan)
            => (double)timeSpan.TotalDays / 365;
    }
}
