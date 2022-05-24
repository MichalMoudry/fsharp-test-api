namespace TestApi.Db

open System
open System.Collections.Generic
open Microsoft.EntityFrameworkCore
open TestApi.Models

module DataContext =
    type CoursesContext () =
        inherit Microsoft.EntityFrameworkCore.DbContext()
            override _.OnConfiguring(optionsBuilder) =
                optionsBuilder.UseSqlite("Data Source=courses.db") |> ignore

        member self.Courses = self.Set<Course>()

        //let mutable courses: DbSet<Course> = null

        //member _.Courses
            //with get() = courses
            //and set (value) = courses <- value

        //[<DefaultValue()>]
        //val mutable courses: DbSet<Course>

        //member public this.Courses
            //with get() = this.courses
            //and set (value) = this.courses <- value
        
        //member this.GetCourse(id: string) =
            //this.courses.SingleOrDefault(fun i -> i.ID.Equals(id))