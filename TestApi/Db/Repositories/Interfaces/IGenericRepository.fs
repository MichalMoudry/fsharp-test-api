namespace TestApi.Db.Repositories.Interfaces

open System

type IGenericRepository<'T> =
    abstract member GetAll: unit -> array<'T>
    /// Method for obtaining an entity by a Guid.
    abstract member GetById:
        id: Guid
        -> 'T
    abstract member Add:
        entity: 'T
        -> bool
    abstract member Update:
        entity: 'T
        -> bool
    abstract member Delete:
        id: Guid
        -> bool