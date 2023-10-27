using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auths;

public static class AuthorisationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeLoggedIn", a =>
                a.RequireAuthenticatedUser());
        });
    }
}