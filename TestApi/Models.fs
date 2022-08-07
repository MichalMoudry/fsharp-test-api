namespace TestApi.Models

open System
open System.ComponentModel.DataAnnotations
open System.Collections.Generic
open AspNetCore.Authentication.ApiKey
open System.Security.Claims

/// Course's tag
[<CLIMutable>]
type Tag = {
    [<Key>] Id: Guid
    Name: string
    DateAdded: DateTime
    mutable DateUpdated: DateTime
}

/// Course type.
[<CLIMutable>]
type Course = {
    [<Key>] mutable Id: Guid
    mutable Name: string
    DateAdded: DateTime
    mutable DateUpdated: DateTime
}

[<CLIMutable>]
type CoursesTags = {
    [<Key>] Id: Guid
    TagId: Guid
    CourseId: Guid
}

/// Class representing an API key.
type ApiKey(key: string, isValid: bool, owner: string, ?claims: List<Claim>) =
    interface IApiKey with
        member _.Claims: IReadOnlyCollection<Claim> =
            if claims.IsSome then
                claims.Value
            else
                new List<Claim>()
        member _.Key: string =
            key
        member _.OwnerName: string = 
            owner
    member _.IsValid: bool =
        isValid