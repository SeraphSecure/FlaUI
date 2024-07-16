using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface ITextChildPattern : IPattern
    {
        AutomationElement TextContainer { get; }
        ITextRange TextRange { get; }
    }
}
