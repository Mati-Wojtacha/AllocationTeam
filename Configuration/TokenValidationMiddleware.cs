using AllocationTeamAPI.Interfaces;

namespace AllocationTeamAPI.Configuration
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITokenManager tokenManager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && !tokenManager.IsTokenActive(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token is revoked or invalid.");
                return;
            }

            await _next(context);
        }
    }
}
