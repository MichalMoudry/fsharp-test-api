namespace TestApi.Controllers

open Microsoft.AspNetCore.Mvc
open TestApi.Models
open TestApi.Db.Repositories.Interfaces
open TestApi.Db.Repositories
open TestApi.Db
open System
open Microsoft.AspNetCore.Authorization
open Ardalis.GuardClauses

[<Authorize>]
[<ApiController>]
[<Route("[controller]")>]
type CoursesController (context: DataContext.DatabaseContext) =
    inherit ControllerBase()

    let coursesOps = (new CoursesRepository(context) :> IGenericRepository<Course>)

    [<HttpGet>]
    member _.Get() =
        coursesOps.GetAll()
    
    [<HttpGet("{id}")>]
    member this.Get(id: string): IActionResult =
        let parseResult, guid = Guid.TryParse(id)
        if parseResult then
            this.Ok(coursesOps.GetById(guid))
        else
            this.BadRequest("Invalid id.")
    
    [<HttpPost>]
    member this.Post(course: Course): IActionResult =
        Guard.Against.Null(course, nameof(course)) |> ignore
        course.Id <- Guid.NewGuid()
        this.Ok()
        (*task {
            coursesOps.AddCourse(course) |> ignore
        } |> ignore
        this.Ok(course)*)

    [<HttpPut>]
    member this.Put(course: Course): IActionResult =
        let updateTask = coursesOps.Update(course)
        (*¨
        updateTask.Wait()
        match updateTask.Result with
            | true -> this.Ok(course)
            | false -> this.BadRequest("Entity does not exist.")
        *)
        this.Ok()

    [<HttpDelete("{id}")>]
    member this.Delete(id: string): IActionResult =
        let parseResult, guid = Guid.TryParse(id)
        if parseResult then
            task {
                coursesOps.Delete(guid) |> ignore
            } |> ignore
            this.Ok("Object was deleted.")
        else
            this.BadRequest("Invalid id.")