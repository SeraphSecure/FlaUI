using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface IObjectModelPattern : IPattern
    {
        object GetUnderlyingObjectModel();
    }
}
