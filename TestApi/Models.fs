namespace TestApi.Models

open System
open System.ComponentModel.DataAnnotations

/// An abstract class that represents and entity within the system.
[<AbstractClass>]
type Entity (ID: string, DateAdded: DateTime, DateUpdated: DateTime) =
    let mutable dateAdded, dateUpdated = DateAdded, DateUpdated
    
    /// Unique identifier of an entity.
    [<Required>]
    member _.ID with get() = ID

    /// Date when an entity was created.
    [<Required>]
    member _.DateAdded
        with get() = dateAdded
        and set (value) = dateAdded <- value

    /// Date when an entity was updated.
    [<Required>]
    member _.DateUpdated
        with get() = dateUpdated
        and set (value) = dateUpdated <- value

//type Course (ID: string, DateAdded: DateTime, DateUpdated: DateTime, Name: string) =
    //inherit Entity(ID, DateAdded, DateUpdated)
    //let mutable name = Name

    //[<Required>]
    //member _.Name
        //with get() = name
        //and set (value) = name <- value

/// Course type.
[<CLIMutable>]
type Course = {
    ID: string
    Name: string
    DateAdded: DateTime
    DateUpdated: DateTime
}