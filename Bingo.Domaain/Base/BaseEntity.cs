using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Base
{
    public abstract class BaseEntity
    {
        //Por si quieres compartir algun campo diferente al id, como fecha de creacion  
    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
