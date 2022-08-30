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
        member _.Add(entity: Course) =
            true
        member _.Update(entity: Course) =
            true
        member _.Delete(id: Guid) =
            true