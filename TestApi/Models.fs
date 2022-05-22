namespace TestApi

module Models =
    open System

    type Course =
        {
            ID: string
            Name: string
            DateAdded: DateTime
            DateUpdated: DateTime
        }