namespace Homework15.Middlewares;

public class MyMiddleware
{
    private readonly RequestDelegate _next;
    private IConfiguration _configuration;

    public MyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {
        var switchapp = _configuration.GetSection("Information").GetChildren().FirstOrDefault(x => x.Key == "BookingNotAllowed")?.Value;
        if (bool.Parse(switchapp))
        {
            await context.Response.WriteAsync($"<h1>Booking is impossible</h1>");
        }
        else
        {
            await _next(context);
        }
    }
    
}