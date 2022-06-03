﻿// <auto-generated />
namespace TestApi.Migrations

open System
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open Microsoft.EntityFrameworkCore.Metadata
open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Storage.ValueConversion
open TestApi.Db

[<DbContext(typeof<DataContext.CoursesContext>)>]
[<Migration("20220528125714_ChangedCourseModel")>]
type ChangedCourseModel() =
    inherit Migration()

    override this.Up(migrationBuilder:MigrationBuilder) =
        ()

    override this.Down(migrationBuilder:MigrationBuilder) =
        ()

    override this.BuildTargetModel(modelBuilder: ModelBuilder) =
        modelBuilder.HasAnnotation("ProductVersion", "6.0.5") |> ignore

        modelBuilder.Entity("TestApi.Models.Course", (fun b ->

            b.Property<string>("ID")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<DateTime>("DateAdded")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<DateTime>("DateUpdated")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("Name")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.HasKey("ID")
                |> ignore


            b.ToTable("Courses") |> ignore

        )) |> ignore
