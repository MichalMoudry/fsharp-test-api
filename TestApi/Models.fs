namespace TestApi.Models

open System
open System.ComponentModel.DataAnnotations
open System.Collections.Generic
open AspNetCore.Authentication.ApiKey
open System.Security.Claims

/// Course type.
[<CLIMutable>]
type Course = {
    [<Key>] ID: string
    mutable Name: string
    DateAdded: DateTime
    mutable DateUpdated: DateTime
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