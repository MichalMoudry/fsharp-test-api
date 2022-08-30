namespace TestApi.Db.Repositories.Interfaces

open System

/// Interface for a generic repository.
type IGenericRepository<'T> =
    /// Method for obtaining all the entities as an array.
    abstract member GetAll: unit -> array<'T>

    /// Method for obtaining an entity by a Guid.
    abstract member GetById:
        id: Guid
        -> 'T

    /// <summary>Method for adding a new entity to db.</summary>
    /// <param name="entity">A new entity.</param>
    abstract member Add:
        entity: 'T
        -> bool

    /// <summary>Method for updating an entity in db.</summary>
    /// <param name="entity">Entity with new data.</param>
    abstract member Update:
        entity: 'T
        -> bool

    /// <summary>Method for removing an entity from db.</summary>
    /// <param name="id">ID of an entity.</param>
    abstract member Delete:
        id: Guid
        -> bool