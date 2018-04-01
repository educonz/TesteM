using Core.UtilsServices;
using Domain.Autenticacoes;
using Domain.Usuarios.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace TesteMeta.Providers
{
    public class AutenticacaoJwt : IAutenticacao
    {
        private const string KEY_APPLICATION = "hpUP8nYwGu4OI5L0yfrM10jZdV0c2ZIgv2iNldb/oN+tu7alcQe0IgGD4dUGR1ilq9RRX3aRxIBctoLl7Nu/Fg==";
        private const double EXPIRE_IN_MINUTES = 60;
        private readonly IDateTimeService _dateTimeService;

        public AutenticacaoJwt(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var symmetricKey = Convert.FromBase64String(KEY_APPLICATION);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(EXPIRE_IN_MINUTES),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return token;
        }

        public (bool IsValid, ClaimsPrincipal Usuario) ValidateToken(string token)
        {
            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return (false, default(ClaimsPrincipal));

            if (!identity.IsAuthenticated)
                return (false, default(ClaimsPrincipal));

            var usernameClaim = identity.FindFirst(UsuarioService.USUARIO);
            var username = usernameClaim?.Value;

            return (true, simplePrinciple);
        }

        private ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(KEY_APPLICATION);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}
