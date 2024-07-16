using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Converters;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class SpreadsheetPattern : PatternBase<UIA.IUIAutomationSpreadsheetPattern>, ISpreadsheetPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetPatternId, "Spreadsheet", AutomationObjectIds.IsSpreadsheetPatternAvailableProperty);

        public SpreadsheetPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationSpreadsheetPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public AutomationElement GetItemByName(string name)
        {
            var nativeElement = Com.Call(() => NativePattern.GetItemByName(name));
            return AutomationElementConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeElement);
        }
    }
}
