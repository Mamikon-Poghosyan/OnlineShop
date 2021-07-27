using System;

namespace OnlineShop.Core.Abstractions
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
