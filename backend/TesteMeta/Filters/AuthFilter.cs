using Core.Configuration;
using Domain.Autenticacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace TesteMeta.Filters
{
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly IAutenticacao _autenticacao;
        private readonly IAppConfiguration _appConfiguration;

        public AuthFilter(IAutenticacao autenticacao,
            IAppConfiguration appConfiguration)
        {
            _autenticacao = autenticacao;
            _appConfiguration = appConfiguration; 
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var urlsSkip = _appConfiguration.Configuration["SkipUrlsAuth"]?.Split("|").Select(x => x.ToLower());

            if (urlsSkip == null || !urlsSkip.Contains(context.HttpContext.Request.Path.ToString().ToLower()))
            {
                var token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "AUTH").Value;
                if (!token.Any())
                {
                    context.Result = new ContentResult
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        ContentType = "text/plain",
                        Content = "Token não informado!"
                    };
                    return;
                }

                var (IsValid, Usuario) = _autenticacao.ValidateToken(token);
                if (!IsValid)
                {
                    context.Result = new ContentResult
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        ContentType = "text/plain",
                        Content = "Token inválido!"
                    };
                    return;
                }

                context.HttpContext.User = Usuario;
            }            
        }
    }
}
