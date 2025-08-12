using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.UIA3.Converters;
using SeraphSecure.FlaUI.UIA3.Extensions;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3
{
    /// <summary>
    /// Class for a UIA3 tree walker.
    /// </summary>
    public class UIA3TreeWalker : ITreeWalker
    {
        /// <summary>
        /// Creates a UIA3 tree walker.
        /// </summary>
        public UIA3TreeWalker(UIA3Automation automation, UIA.IUIAutomationTreeWalker nativeTreeWalker, CacheRequest? cacheRequest = null)
        {
            Automation = automation;
            NativeTreeWalker = nativeTreeWalker;
            CacheRequest = cacheRequest;
        }

        /// <summary>
        /// The current <see cref="AutomationBase"/> object.
        /// </summary>
        public UIA3Automation Automation { get; }

        /// <summary>
        /// The native tree walker object.
        /// </summary>
        public UIA.IUIAutomationTreeWalker NativeTreeWalker { get; }

        /// <summary>
        /// The cache request to use while walking through the tree.
        /// </summary>
        public CacheRequest? CacheRequest { get; }

        /// <inheritdoc />
        public AutomationElement GetParent(AutomationElement element)
        {
            var parent = CacheRequest == null ?
                NativeTreeWalker.GetParentElement(element.ToNative()) :
                NativeTreeWalker.GetParentElementBuildCache(element.ToNative(), CacheRequest.ToNative(Automation));
            return Automation.WrapNativeElement(parent);
        }

        /// <inheritdoc />
        public AutomationElement GetFirstChild(AutomationElement element)
        {
            var child = CacheRequest == null ?
                NativeTreeWalker.GetFirstChildElement(element.ToNative()) :
                NativeTreeWalker.GetFirstChildElementBuildCache(element.ToNative(), CacheRequest.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetLastChild(AutomationElement element)
        {
            var child = CacheRequest == null ?
                NativeTreeWalker.GetLastChildElement(element.ToNative()) :
                NativeTreeWalker.GetLastChildElementBuildCache(element.ToNative(), CacheRequest.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetNextSibling(AutomationElement element)
        {
            var child = CacheRequest == null ?
                NativeTreeWalker.GetNextSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetNextSiblingElementBuildCache(element.ToNative(), CacheRequest.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetPreviousSibling(AutomationElement element)
        {
            var child = CacheRequest == null ?
                NativeTreeWalker.GetPreviousSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetPreviousSiblingElementBuildCache(element.ToNative(), CacheRequest.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }
    }
}
