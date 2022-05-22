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
            { 
                ID = Guid.NewGuid().ToString();
                Name = "Test course 1";
                DateAdded = DateTime.Now;
                DateUpdated = DateTime.Now; 
            }
            { 
                ID = Guid.NewGuid().ToString();
                Name = "Test course 2";
                DateAdded = DateTime.Now;
                DateUpdated = DateTime.Now; 
            }
            { 
                ID = Guid.NewGuid().ToString();
                Name = "Test course 3";
                DateAdded = DateTime.Now;
                DateUpdated = DateTime.Now; 
            }
        |]

    [<HttpGet>]
    member _.Get() =
        courses