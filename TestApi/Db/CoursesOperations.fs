namespace TestApi.Db

open TestApi.Db.DataContext
open TestApi.Models

type CoursesOperations(context: CoursesContext) =
    let dbContext = context

    /// Function for adding a new course to db.
    member _.AddCourse(course: Course) =
        true