using System;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;

namespace SeraphSecure.FlaUI.Core.EventHandlers
{
    /// <summary>
    /// Base event handler for structure changed event handlers.
    /// </summary>
    public abstract class StructureChangedEventHandlerBase : ElementEventHandlerBase
    {
        private readonly Action<AutomationElement, StructureChangeType, int[]> _callAction;

        protected StructureChangedEventHandlerBase(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, StructureChangeType, int[]> callAction)
            : base(frameworkElement)
        {
            _callAction = callAction;
        }

        protected void HandleStructureChangedEvent(AutomationElement sender, StructureChangeType changeType, int[] runtimeId)
        {
            _callAction(sender, changeType, runtimeId);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            FrameworkElement.UnregisterStructureChangedEventHandler(this);
        }
    }
}
