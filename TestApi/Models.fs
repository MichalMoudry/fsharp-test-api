namespace TestApi.Models

open System
open System.ComponentModel.DataAnnotations

/// Course type.
[<CLIMutable>]
type Course = {
    [<Key>] ID: string
    mutable Name: string
    DateAdded: DateTime
    mutable DateUpdated: DateTime
}