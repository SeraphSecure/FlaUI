using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface ISpreadsheetPattern : IPattern
    {
        AutomationElement GetItemByName(string name);
    }
}
