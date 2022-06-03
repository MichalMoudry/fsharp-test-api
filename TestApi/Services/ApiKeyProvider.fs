namespace TestApi.Services

open AspNetCore.Authentication.ApiKey
open TestApi.Models
open Microsoft.Extensions.Configuration
open System.Linq
open System.Threading.Tasks

type ApiKeyProvider(config: IConfiguration) =
    let _configuration = config
    let apiKeys = [
        new ApiKey("key1", "Test user 1")
        new ApiKey("key2", "Test user 2")
    ]

    interface IApiKeyProvider with
        member _.ProvideAsync(key: string) =
            //let is_config_key = System.Convert.ToBoolean(_configuration[$"ApiKeys:{key}"])
            let clientKey = apiKeys.SingleOrDefault(fun i -> (i :> IApiKey).Key.Equals(key))
            Task.FromResult(clientKey)