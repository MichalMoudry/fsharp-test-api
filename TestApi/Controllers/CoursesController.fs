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
    member this.Post(course: Course): IActionResult =
        if not (String.IsNullOrEmpty(course.ID)) then
            task {
                coursesOps.AddCourse(course) |> ignore
            } |> ignore
            this.Ok("Entity was added.")
        else
            this.BadRequest("Entity needs an ID.")

    [<HttpPut>]
    member _.Put(course: Course) =
        printfn $"PUT: {course}"

    [<HttpDelete("{id}")>]
    member _.Delete(id: string) =
        printfn $"DELETE: {id}"