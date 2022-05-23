namespace TestApi.Db

open System
open System.Collections.Generic
open Microsoft.EntityFrameworkCore
open TestApi.Models
open System.Linq

module DataContext =
    type CoursesContext (options: DbContextOptions<CoursesContext>) =
        inherit DbContext(options)

        [<DefaultValue()>]
        val mutable courses: DbSet<Course>

        member public this.Courses
            with get() = this.courses
            and set (value) = this.courses <- value
        
        member this.GetCourse(id: string) =
            this.courses.SingleOrDefault(fun i -> i.ID.Equals(id))