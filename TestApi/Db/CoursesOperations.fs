namespace TestApi.Db

open TestApi.Db.DataContext
open TestApi.Models
open System.Linq

/// Class representing operations that relate to Course entity.
type CoursesOperations(context: CoursesContext) =
    let dbContext = context

    /// Method for adding a new course to db.
    member _.AddCourse(course: Course) =
        task {
            dbContext.Courses.Add(course) |> ignore
            dbContext.SaveChangesAsync() |> ignore
            return true
        }

    /// Method for obtaining a single Course entity.
    member _.GetCourse(courseID: string) =
        try
            Some(dbContext.Courses.Single(fun i -> i.ID.Equals(courseID)))
        with
            | :? System.InvalidOperationException -> None

    /// Method for obtaining all the courses as an array.
    member _.GetCourses() =
        dbContext.Courses.ToArray()

    /// <summary>Method for removing a course from db.</summary>
    /// <param name="courseID">ID of a course.</param>
    member this.DeleteCourse(courseID: string) =
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
            let course = this.GetCourse(newCourseData.ID)
            if course.IsSome then
                course.Value.Name <- newCourseData.Name
                course.Value.DateUpdated <- System.DateTime.Now
                dbContext.SaveChangesAsync() |> ignore
                return true
            else
                return false
        }