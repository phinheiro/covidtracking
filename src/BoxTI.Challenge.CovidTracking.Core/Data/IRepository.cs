using System;
using BoxTI.Challenge.CovidTracking.Core.Entities;

namespace BoxTI.Challenge.CovidTracking.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}