using Microsoft.AspNetCore.Mvc;
using NotificationPattern.Contracts;
using NotificationPattern.Infra.Api;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace NotificationPattern.Features;

public static class CreateCatEndpoint
{
    public static void UseCreateCat(this WebApplication app)
    {
        app.MapPost("/cats", CreateCat);
    }

    private static async Task<IResult> CreateCat([FromBody] CreateCatRequest dto, ICreateCatService service)
    {
        var result = await service.CreateCat(dto.Name, dto.Age, dto.FavoriteToy, dto.WhiskerLength, dto.NapTime);

        return ResultPresenter.ToHttpResult<CreateCatResponse>(result);
    }
}
