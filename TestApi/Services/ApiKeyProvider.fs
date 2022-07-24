namespace TestApi.Services

open AspNetCore.Authentication.ApiKey
open TestApi.Models
open Microsoft.Extensions.Configuration
open System.Linq
open System.Threading.Tasks

type ApiKeyProvider(config: IConfiguration) =
    let _configuration = config

    interface IApiKeyProvider with
        member _.ProvideAsync(key: string) =
            let isKeyValid = System.Convert.ToBoolean(_configuration[$"ApiKeys:{key}:IsValid"])
            if isKeyValid then
                let owner = _configuration[$"ApiKeys:{key}:Owner"]
                Task.FromResult(new ApiKey(key, isKeyValid, owner))
            else
                Task.FromResult(null)