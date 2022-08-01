using System;

namespace Fengchao.Gallery.Core.Boolean
{
    /// <summary>
    /// Provides extension methods for <see cref="bool"/>.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Executes the specified action if the given condition is true.
        /// </summary>
        /// <param name="condition">The condition to be judged.</param>
        /// <param name="action">The action to execute when condition is true.</param>
        public static void ExecuteIfTrue(this bool condition, Action action)
        {
            if (condition)
            {
                action.Invoke();
            }
        }

        /// <summary>
        /// Executes the specified action if the given condition is false.
        /// </summary>
        /// <param name="condition">The condition to be judged.</param>
        /// <param name="action">The action to execute when condition is false.</param>
        public static void ExecuteIfFalse(this bool condition, Action action)
        {
            if (!condition)
            {
                action.Invoke();
            }
        }

        /// <summary>
        /// Throws a specified exception out if the given condition is false.
        /// </summary>
        /// <param name="condition">The condition to be judged.</param>
        /// <param name="ex">The exception to be throwed out when condition is false.</param>
        public static void MustBeTrue(this bool condition, Exception ex)
        {
            if (!condition)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Throws a specified exception out if the given condition is true.
        /// </summary>
        /// <param name="condition">The condition to be judged.</param>
        /// <param name="ex">The exception to be throwed out when condition is true.</param>
        public static void MustBeFalse(this bool condition, Exception ex)
        {
            if (condition)
            {
                throw ex;
            }
        }
    }
}
