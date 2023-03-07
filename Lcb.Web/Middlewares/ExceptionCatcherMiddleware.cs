﻿using System.Net;
using Lcb.BLL;
using Lcb.BLL.Misc;

namespace Lcb.Web.Middlewares;

public class ExceptionCatcherMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionCatcherMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context /* other dependencies */)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new ErrorDto(ex.Message));
        }
    }
}