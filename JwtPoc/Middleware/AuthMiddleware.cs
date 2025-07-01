using Microsoft.AspNetCore.Authorization;

namespace JwtPoc.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // This will validate if the required resource if behind authorize or AllowAnonymous
            var endpoint = context.GetEndpoint();
            var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;

            // If the requested resource is AllowAnonymous == true,
            // then there is no need for authenticating/validating a token
            if (allowAnonymous)
            {
                await _next(context);
                return;
            }
            // Below we can also apply any validation we wants to. [Relvant to token]
            // Like we want to extract details from token.
            // set those details to a request context and use that through the request context.
            // Validate session from token and use to verify, if single sign-in is allowed.

            await _next(context);
        }   
    }
}
