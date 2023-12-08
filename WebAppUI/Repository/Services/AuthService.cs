using Modules.Security.Domain.Dtos;
using Modules.Security.Domain.Shared;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using WebAppUI.Repository.Interfaces;

namespace WebAppUI.Repository.Services;

public sealed class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _JsonOptions;

    public AuthService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
    {
        _httpClient = httpClient;
        _JsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<Result> RegisterUser(UserRegistrationForm userRegistration)
    {
        var registrationFormToJson = JsonSerializer.Serialize(userRegistration);

        var prepareStringContent = new StringContent(registrationFormToJson, Encoding.UTF8, "application/json");

        var registrationResult = await _httpClient.PostAsync("register", prepareStringContent);
        var registrationContent = await registrationResult.Content.ReadAsStringAsync();

        if (!registrationResult.IsSuccessStatusCode)
        {
            var result = JsonSerializer.Deserialize<Result>(registrationContent, _JsonOptions);

            return result!;
        }
       
        return Result.Success();
    }
}
