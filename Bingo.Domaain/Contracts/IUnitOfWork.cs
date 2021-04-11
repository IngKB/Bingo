using Bingo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Contracts
{
    public interface IUnitOfWork
    {
        ICartonRepository CartonRepository { get; }
        int Commit();
    }
}
