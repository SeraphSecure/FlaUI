#if NETFRAMEWORK
using Accessibility;
using SeraphSecure.FlaUI.Core.Tools;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public partial class LegacyIAccessiblePattern
    {
        public override IAccessible GetIAccessible()
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return Com.Call(() => (IAccessible)NativePattern.GetIAccessible());
        }
    }
}
#endif
