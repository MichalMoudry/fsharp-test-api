namespace TestApi.Db

open System
open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions
open TestApi.Models

module DataContext =
    type DatabaseContext () =
        inherit DbContext()

        [<DefaultValue>]
        val mutable private courses: DbSet<Course>

        [<DefaultValue>]
        val mutable private tags: DbSet<Tag>

        [<DefaultValue>]
        val mutable private coursesTags: DbSet<CoursesTags>

        member this.Courses
            with get() = this.courses
            and set (value) = this.courses <- value
        
        member this.Tags
            with get() = this.tags
            and set (value) = this.tags <- value
        
        member this.CoursesTags
            with get() = this.coursesTags
            and set (value) = this.coursesTags <- value

        override _.OnModelCreating(builder) =
            builder.RegisterOptionTypes()
            let courses =
                [|
                    {Id = Guid.NewGuid(); Name = "Test course 1"; DateAdded = DateTime.Now; DateUpdated = DateTime.Now}
                    {Id = Guid.NewGuid(); Name = "Test course 2"; DateAdded = DateTime.Now; DateUpdated = DateTime.Now}
                    {Id = Guid.NewGuid(); Name = "Test course 3"; DateAdded = DateTime.Now; DateUpdated = DateTime.Now}
                |] : array<Course>
            let tags =
                [|
                    {Id = Guid.NewGuid(); Name = "Tag 1"; DateAdded = DateTime.Now; DateUpdated = DateTime.Now}
                    {Id = Guid.NewGuid(); Name = "Tag 2"; DateAdded = DateTime.Now; DateUpdated = DateTime.Now}
                    {Id = Guid.NewGuid(); Name = "Tag 3"; DateAdded = DateTime.Now; DateUpdated = DateTime.Now}
                |] : array<Tag>
            let coursesTags =
                [|
                    {Id = Guid.NewGuid(); CourseId = courses[0].Id; TagId = tags[0].Id}
                    {Id = Guid.NewGuid(); CourseId = courses[0].Id; TagId = tags[1].Id}
                    {Id = Guid.NewGuid(); CourseId = courses[1].Id; TagId = tags[0].Id}
                    {Id = Guid.NewGuid(); CourseId = courses[1].Id; TagId = tags[1].Id}
                    {Id = Guid.NewGuid(); CourseId = courses[1].Id; TagId = tags[2].Id}
                |] : array<CoursesTags>
            builder.Entity<Course>().HasData(courses) |> ignore
            builder.Entity<Tag>().HasData(tags) |> ignore
            builder.Entity<CoursesTags>().HasData(coursesTags) |> ignore

        override _.OnConfiguring(optionsBuilder) =
            optionsBuilder.UseSqlite("Data Source=courses.db") |> ignore