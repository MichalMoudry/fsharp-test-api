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
            new Course(Guid.NewGuid().ToString(), DateTime.Now, DateTime.Now, "Test course 1")
            new Course(Guid.NewGuid().ToString(), DateTime.Now, DateTime.Now, "Test course 2")
            new Course(Guid.NewGuid().ToString(), DateTime.Now, DateTime.Now, "Test course 3")
        |]

    [<HttpGet>]
    member _.Get() =
        courses