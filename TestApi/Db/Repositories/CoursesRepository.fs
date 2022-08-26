namespace TestApi.Db.Repositories

open System
open TestApi.Db.DataContext
open TestApi.Models
open System.Linq
open Microsoft.EntityFrameworkCore

/// Repository related to Course entity.
type CoursesRepository(context: DatabaseContext) =
    let dbContext = context

    /// Method for adding a new course to db.
    member _.AddCourse(course: Course) =
        task {
            dbContext.Courses.Add(course) |> ignore
            let! numberOfEntites = dbContext.SaveChangesAsync() |> Async.AwaitTask
            if numberOfEntites > 0 then
                return true
            else
                return false
        }

    /// Method for obtaining a single Course entity.
    member _.GetCourse(courseID: Guid) =
        try
            Some(dbContext.Courses.Single(fun i -> i.Id.Equals(courseID)))
        with
            | :? InvalidOperationException -> None

    /// Method for obtaining all the courses as an array.
    member _.GetCourses() =
        dbContext.Courses.AsNoTracking().ToArray()

    /// <summary>Method for removing a course from db.</summary>
    /// <param name="courseID">ID of a course.</param>
    member this.DeleteCourse(courseID: Guid) =
        task {
            let course = this.GetCourse(courseID)
            if course.IsSome then
                dbContext.Courses.Remove(course.Value) |> ignore
                dbContext.SaveChangesAsync() |> ignore
                return true
            else
                return false
        }

    /// Method for updating an entity.
    member this.UpdateCourse(newCourseData: Course) =
        task {
            let course = this.GetCourse(newCourseData.Id)
            if course.IsSome then
                course.Value.Name <- newCourseData.Name
                course.Value.DateUpdated <- DateTime.Now
                dbContext.SaveChangesAsync() |> ignore
                return true
            else
                return false
        }