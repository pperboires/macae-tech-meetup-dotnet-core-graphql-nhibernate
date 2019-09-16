
namespace Perb.Framework.Infrastructure
{
    public interface IAppSettingsRetriever
    {
        string GetValue(string key, bool secret = false);
    }
}