using System.Threading.Tasks;
using Perb.Framework.Domains.Write.Commands;

namespace Perb.Framework.Domains.Write
{
    public interface ICommandRouter
    {
        Task Send(Command cmd);
    }
}