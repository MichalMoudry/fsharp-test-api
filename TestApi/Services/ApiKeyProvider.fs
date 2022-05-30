namespace TestApi.Services

open AspNetCore.Authentication.ApiKey
open TestApi.Models
open Microsoft.Extensions.Configuration

type ApiKeyProvider(config: IConfiguration) =
    let _configuration = config

    interface IApiKeyProvider with
    
        member _.ProvideAsync(key: string) =
            let is_config_key = System.Convert.ToBoolean(_configuration[$"ApiKeys:{key}"])
            let test = new ApiKey(key, "test_user")
            task {
                return null
            }