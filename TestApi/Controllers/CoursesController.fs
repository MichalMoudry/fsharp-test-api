namespace TestApi.Controllers

open Microsoft.AspNetCore.Mvc
open TestApi.Models
open TestApi.Db.Repositories
open TestApi.Db
open System
open Microsoft.AspNetCore.Authorization

[<Authorize>]
[<ApiController>]
[<Route("[controller]")>]
type CoursesController (context: DataContext.DatabaseContext) =
    inherit ControllerBase()

    let coursesOps = new CoursesRepository(context)

    [<HttpGet>]
    member _.Get() =
        coursesOps.GetCourses()
    
    [<HttpGet("{id}")>]
    member this.Get(id: string): IActionResult =
        let parseResult, guid = Guid.TryParse(id)
        if parseResult then
            let course = coursesOps.GetCourse(guid)
            if course.IsSome then
                this.Ok(course.Value)
            else
                this.BadRequest("Entity with this ID does not exist.")
        else
            this.BadRequest("Invalid id.")
    
    [<HttpPost>]
    member this.Post(course: Course): IActionResult =
        course.Id <- Guid.NewGuid()
        task {
            coursesOps.AddCourse(course) |> ignore
        } |> ignore
        this.Ok(course)

    [<HttpPut>]
    member this.Put(course: Course): IActionResult =
        let updateTask = coursesOps.UpdateCourse(course)
        updateTask.Wait()
        match updateTask.Result with
            | true -> this.Ok(course)
            | false -> this.BadRequest("Entity does not exist.")

    [<HttpDelete("{id}")>]
    member this.Delete(id: string): IActionResult =
        let parseResult, guid = Guid.TryParse(id)
        if parseResult then
            task {
                coursesOps.DeleteCourse(guid) |> ignore
            } |> ignore
            this.Ok("Object was deleted.")
        else
            this.BadRequest("Invalid id.")