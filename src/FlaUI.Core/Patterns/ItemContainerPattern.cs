using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface IItemContainerPattern : IPattern
    {
        AutomationElement? FindItemByProperty(AutomationElement? startAfter, PropertyId? property, object? value);
    }
}
