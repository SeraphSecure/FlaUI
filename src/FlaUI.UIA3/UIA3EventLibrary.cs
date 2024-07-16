using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements.Infrastructure;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.UIA3.Patterns;

namespace SeraphSecure.FlaUI.UIA3
{
    public class UIA3EventLibrary : IEventLibrary
    {
        public UIA3EventLibrary()
        {
            Element = new UIA3AutomationElementEventIds();
            Drag = new DragPatternEventIds();
            DropTarget = new DropTargetPatternEventIds();
            Invoke = new InvokePatternEventIds();
            SelectionItem = new SelectionItemPatternEventIds();
            Selection = new SelectionPatternEventIds();
            SynchronizedInput = new SynchronizedInputPatternEventIds();
            TextEdit = new TextEditPatternEventIdIds();
            Text = new TextPatternEventIds();
            Window = new WindowPatternEventIds();
        }

        public IAutomationElementEventIds Element { get; }
        public IDragPatternEventIds Drag { get; }
        public IDropTargetPatternEventIds DropTarget { get; }
        public IInvokePatternEventIds Invoke { get; }
        public ISelectionItemPatternEventIds SelectionItem { get; }
        public ISelectionPatternEventIds Selection { get; }
        public ISynchronizedInputPatternEventIds SynchronizedInput { get; }
        public ITextEditPatternEventIds TextEdit { get; }
        public ITextPatternEventIds Text { get; }
        public IWindowPatternEventIds Window { get; }
    }
}
