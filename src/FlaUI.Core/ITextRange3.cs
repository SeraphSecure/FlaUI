using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core
{
    public interface ITextRange3 : ITextRange2
    {
        AutomationElement GetEnclosingElementBuildCache(CacheRequest cacheRequest);
        AutomationElement[] GetChildrenBuildCache(CacheRequest cacheRequest);
        object[] GetAttributeValues(TextAttributeId[] attributeIds);
    }
}
