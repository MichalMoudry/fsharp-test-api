namespace TestApi.Db

open System
open System.Collections.Generic
open Microsoft.EntityFrameworkCore

type CoursesContext (options : DbContextOptions<CoursesContext>) =
    inherit DbContext(options)

    //[<DefaultValue()>]
    //val mutable courses: DbSet<Course>