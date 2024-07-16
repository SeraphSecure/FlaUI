using System;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.Exceptions
{
    public class PatternNotCachedException : NotCachedException
    {
        private const string DefaultMessage = "The requested pattern is not cached";
        private const string DefaultMessageWithData = "The requested pattern '{0}' is not cached";

        public PatternNotCachedException() : base(DefaultMessage)
        {
        }

        public PatternNotCachedException(PatternId pattern)
            : base(String.Format(DefaultMessageWithData, pattern))
        {
            Pattern = pattern;
        }

        public PatternNotCachedException(string message, PatternId pattern)
            : base(message)
        {
            Pattern = pattern;
        }

        public PatternNotCachedException(PatternId pattern, Exception innerException)
            : base(String.Format(DefaultMessageWithData, pattern), innerException)
        {
            Pattern = pattern;
        }

        public PatternNotCachedException(string message, PatternId pattern, Exception innerException)
            : base(message, innerException)
        {
            Pattern = pattern;
        }

        public PatternId Pattern { get; }
    }
}
