namespace TestApi.Db.Repositories

open System

type IGenericRepository<'T> =
    abstract member GetAll: array<'T>
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