namespace TestApi.Controllers

open Microsoft.AspNetCore.Mvc
open TestApi.Models
open TestApi.Db
open System
open Microsoft.AspNetCore.Authorization

[<Authorize>]
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
        if course.IsSome then
            this.Ok(course.Value)
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
    member this.Put(course: Course): IActionResult =
        let updateTask = coursesOps.UpdateCourse(course)
        updateTask.Wait()
        match updateTask.Result with
            | true -> this.Ok(course)
            | false -> this.BadRequest("Entity does not exist.")

    [<HttpDelete("{id}")>]
    member this.Delete(id: string): IActionResult =
        task {
            coursesOps.DeleteCourse(id) |> ignore
        } |> ignore
        this.Ok("Object was deleted.")