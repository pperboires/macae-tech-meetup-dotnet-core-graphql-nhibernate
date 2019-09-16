namespace Perb.Framework.Infrastructure
{
    public interface ISecretRetriever
    {
        string GetSecret(string stage, string region, string secretName);
    }
}