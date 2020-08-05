using System;
using System.Data;

namespace Shop.Domain.Context
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}