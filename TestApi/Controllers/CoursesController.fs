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
        coursesOps.GetCourses()
    
    [<HttpGet("{id}")>]
    member this.Get(id: string): IActionResult =
        let course = coursesOps.GetCourse(id)
        let result =
            match box course with
                | null -> false
                | _ -> true
        if result then
            this.Ok(course)
        else
            this.BadRequest("Entity with this ID does not exist.")
    
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
    member this.Delete(id: string): IActionResult =
        task {
            coursesOps.DeleteCourse(id) |> ignore
        } |> ignore
        this.Ok("Object was deleted.")