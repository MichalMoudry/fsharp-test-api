namespace TestApi.Db.Repositories

open System
open TestApi.Db.Repositories.Interfaces
open TestApi.Db.DataContext
open TestApi.Models
open System.Linq
open Microsoft.EntityFrameworkCore

/// Repository related to Course entity.
type CoursesRepository(context: DatabaseContext) =
    let dbContext = context
    interface IGenericRepository<Course> with
        member _.GetAll() =
            dbContext.Courses.AsNoTracking().ToArray()
        member _.GetById(id: Guid) =
            dbContext.Courses.Single(fun i -> i.Id.Equals(id))

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
    member this.GetCourse(id: Guid) =
        (this :> IGenericRepository<Course>).GetById(id)

    /// Method for obtaining all the courses as an array.
    member _.GetCourses() =
        dbContext.Courses.AsNoTracking().ToArray()

    /// <summary>Method for removing a course from db.</summary>
    /// <param name="courseID">ID of a course.</param>
    member this.DeleteCourse(courseID: Guid) =
        task {
            let course = this.GetCourse(courseID)
            dbContext.Courses.Remove(course) |> ignore
            dbContext.SaveChangesAsync() |> ignore
            return true
        }

    /// Method for updating an entity.
    member this.UpdateCourse(newCourseData: Course) =
        task {
            let course = this.GetCourse(newCourseData.Id)
            course.Name <- newCourseData.Name
            course.DateUpdated <- DateTime.Now
            dbContext.SaveChangesAsync() |> ignore
            return true
        }