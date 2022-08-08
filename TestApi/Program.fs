namespace TestApi
#nowarn "20"
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open TestApi.Db.DataContext
open TestApi.Services
open AspNetCore.Authentication.ApiKey

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        /// Config for API key auth.
        let apiKeyConfig (options: ApiKeyOptions) =
            do
                options.Realm <- "Sample Web API"
                options.KeyName <- "X-API-KEY"

        builder.Services.AddControllers()
        builder.Services.AddDbContext<DatabaseContext>()
        builder.Services.AddAuthentication(ApiKeyDefaults.AuthenticationScheme)
            .AddApiKeyInHeader<ApiKeyProvider>(apiKeyConfig)

        let app = builder.Build()

        app.UseHttpsRedirection()

        app.UseAuthentication()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode
