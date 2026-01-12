using System.Net;
using System.Text.Json;

namespace DayOffMini.API.Middlwares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (KeyNotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await WriteErrorAsync(context, ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict; // 409
            await WriteErrorAsync(context, ex.Message);
        }
        catch (Exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await WriteErrorAsync(context, "An unexpected error occurred.");
        }
    }

    private static async Task WriteErrorAsync(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";

        object response = new
        {
            error = message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
