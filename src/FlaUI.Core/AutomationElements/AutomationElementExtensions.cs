using System;
using System.Diagnostics.CodeAnalysis;
using SeraphSecure.FlaUI.Core.Tools;

namespace SeraphSecure.FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Contains extension methods for <see cref="AutomationElement"/>s.
    /// </summary>
    public static partial class AutomationElementExtensions
    {
        /// <summary>
        /// Waits until the element has a clickable point.
        /// </summary>
        [return: NotNullIfNotNull(nameof(self))]
        public static T? WaitUntilClickable<T>(this T? self, TimeSpan? timeout = null) where T : AutomationElement
        {
            if (self != null)
            {
                Retry.WhileFalse(() => self.TryGetClickablePoint(out var _), timeout: timeout, throwOnTimeout: true, ignoreException: true);
            }
            return self;
        }

        /// <summary>
        /// Waits until the element is enabled.
        /// </summary>
        [return: NotNullIfNotNull(nameof(self))]
        public static T? WaitUntilEnabled<T>(this T? self, TimeSpan? timeout = null) where T : AutomationElement
        {
            if (self != null)
            {
                Retry.WhileFalse(() => self.IsEnabled, timeout: timeout, throwOnTimeout: true, ignoreException: true);
            }
            return self;
        }
    }
}
