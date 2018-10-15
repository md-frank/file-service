using System;
using System.Collections.Generic;
using System.Text;

namespace Mondol.FileService.Db.Entities
{
    /// <summary>
    /// Defines interface for base entity type. All entities in the system must implement this interface.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    public interface IIdEntity<TPrimaryKey> : IEntity where TPrimaryKey : struct
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// A shortcut of <see cref="IIdEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    public interface IIdEntity : IIdEntity<int>
    {
    }
}
