namespace TestApi
#nowarn "20"
open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open TestApi.Db.DataContext
open TestApi.Services
open AspNetCore.Authentication.ApiKey

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        let apiKeyConfig (options : ApiKeyOptions) =
            do
                options.Realm <- "Sample Web API"
                options.KeyName <- "X-API-KEY"

        builder.Services.AddControllers()
        builder.Services.AddDbContext<CoursesContext>()
        builder.Services.AddAuthentication(ApiKeyDefaults.AuthenticationScheme)
            .AddApiKeyInHeaderOrQueryParams<ApiKeyProvider>(apiKeyConfig)

        let app = builder.Build()

        app.UseHttpsRedirection()

        app.UseAuthentication()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode
