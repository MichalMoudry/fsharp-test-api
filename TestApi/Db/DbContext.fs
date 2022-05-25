namespace TestApi.Db

open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions
open TestApi.Models

module DataContext =
    type CoursesContext () =
        inherit DbContext()

        [<DefaultValue>]
        val mutable private courses: DbSet<Course>

        member this.Courses
            with get() = this.courses
            and set (value) = this.courses <- value

        override _.OnModelCreating(builder) =
            builder.RegisterOptionTypes()

        override _.OnConfiguring(optionsBuilder) =
            optionsBuilder.UseSqlite("Data Source=courses.db") |> ignore