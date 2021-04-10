using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
