using System.Threading.Tasks;

namespace Financial.Services.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}