using NotificationPattern.Features;
using NotificationPattern.Infra.Repositories;

public static class Dependencies
{
    public static void AddCatServices(this IServiceCollection services)
    {
        services.AddScoped<ICatRepository, CatRepository>();
        services.AddScoped<ICreateCatService, CreateCatService>();
    }
}
