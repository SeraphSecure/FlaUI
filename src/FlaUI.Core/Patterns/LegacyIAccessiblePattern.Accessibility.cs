#if NETFRAMEWORK
using Accessibility;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public partial interface ILegacyIAccessiblePattern
    {
        IAccessible GetIAccessible();
    }

    public abstract partial class LegacyIAccessiblePatternBase<TNativePattern> : ILegacyIAccessiblePattern
        where TNativePattern : class
    {
        public abstract IAccessible GetIAccessible();
    }
}
#endif
