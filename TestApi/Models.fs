namespace TestApi.Models

open System
open System.ComponentModel.DataAnnotations

/// Course type.
[<CLIMutable>]
type Course = {
    [<Key>] ID: string
    Name: string
    DateAdded: DateTime
    DateUpdated: DateTime
}