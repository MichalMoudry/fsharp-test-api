namespace TestApi.Controllers

open Microsoft.AspNetCore.Mvc
open TestApi.Models
open TestApi.Db
open System

[<ApiController>]
[<Route("[controller]")>]
type CoursesController (context: DataContext.CoursesContext) =
    inherit ControllerBase()

    let coursesOps = new CoursesOperations(context)

    [<HttpGet>]
    member _.Get() =
        [|
            5
            1
            3
        |]
    
    [<HttpGet("{id}")>]
    member _.Get(id: string) =
        id
    
    [<HttpPost>]
    member _.Post(course: Course) =
        //coursesOps.AddCourse(course) |> ignore
        printfn $"POST: {course}"

    [<HttpPut>]
    member _.Put(course: Course) =
        printfn $"PUT: {course}"

    [<HttpDelete("{id}")>]
    member _.Delete(id: string) =
        printfn $"DELETE: {id}"