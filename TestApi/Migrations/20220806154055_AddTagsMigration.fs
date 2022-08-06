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
[<Migration("20220806154055_AddTagsMigration")>]
type AddTagsMigration() =
    inherit Migration()

    override this.Up(migrationBuilder:MigrationBuilder) =
        migrationBuilder.RenameColumn(
            name = "ID"
            ,table = "Courses"
            ,newName = "Id"
            ) |> ignore

        migrationBuilder.CreateTable(
            name = "Tag"
            ,columns = (fun table -> 
            {|
                ID =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                Name =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                DateAdded =
                    table.Column<DateTime>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                DateUpdated =
                    table.Column<DateTime>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
                CourseId =
                    table.Column<string>(
                        nullable = false
                        ,``type`` = "TEXT"
                    )
            |})
            , constraints =
                (fun table -> 
                    table.PrimaryKey("PK_Tag", (fun x -> (x.ID) :> obj)
                    ) |> ignore
                    table.ForeignKey(
                        name = "FK_Tag_Courses_CourseId"
                        ,column = (fun x -> (x.CourseId) :> obj)
                        ,principalTable = "Courses"
                        ,principalColumn = "Id"
                        ) |> ignore

                )
        ) |> ignore

        migrationBuilder.CreateIndex(
            name = "IX_Tag_CourseId"
            ,table = "Tag"
            ,column = "CourseId"
            ) |> ignore


    override this.Down(migrationBuilder:MigrationBuilder) =
        migrationBuilder.DropTable(
            name = "Tag"
            ) |> ignore

        migrationBuilder.RenameColumn(
            name = "Id"
            ,table = "Courses"
            ,newName = "ID"
            ) |> ignore


    override this.BuildTargetModel(modelBuilder: ModelBuilder) =
        modelBuilder.HasAnnotation("ProductVersion", "6.0.5") |> ignore

        modelBuilder.Entity("TestApi.Models.Course", (fun b ->

            b.Property<string>("Id")
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

            b.HasKey("Id")
                |> ignore


            b.ToTable("Courses") |> ignore

        )) |> ignore

        modelBuilder.Entity("TestApi.Models.Tag", (fun b ->

            b.Property<string>("ID")
                .IsRequired(true)
                .HasColumnType("TEXT")
                |> ignore

            b.Property<string>("CourseId")
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


            b.HasIndex("CourseId")
                |> ignore

            b.ToTable("Tag") |> ignore

        )) |> ignore
        modelBuilder.Entity("TestApi.Models.Tag", (fun b ->
            b.HasOne("TestApi.Models.Course", null)
                .WithMany("Tags")
                .HasForeignKey("CourseId")
                |> ignore

        )) |> ignore
        modelBuilder.Entity("TestApi.Models.Course", (fun b ->

            b.Navigation("Tags")
            |> ignore
        )) |> ignore

