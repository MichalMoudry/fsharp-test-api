namespace TestApi.Controllers

open Microsoft.AspNetCore.Mvc
open TestApi.Models
open System

[<ApiController>]
[<Route("[controller]")>]
type CoursesController () =
    inherit ControllerBase()
    
    let courses =
        [|
            5
            1
            3
        |]

    [<HttpGet>]
    member _.Get() =
        courses