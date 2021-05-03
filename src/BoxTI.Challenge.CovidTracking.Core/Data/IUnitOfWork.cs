using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}