
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BusinessRespository.Utility {
  public  class AuthUtilities
    {
          public static string GenerateToken(dynamic data, string Username)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF32.GetBytes(Username));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(signingCredentials);
            List<Claim> claims = new List<Claim>
            {
                new Claim("Username",Username),
                new Claim("Userrecord",JsonConvert.SerializeObject(data)),
            };
            JwtPayload payload = new JwtPayload(issuer: "*", audience: "*", issuedAt: DateTime.Now, expires: DateTime.Now.AddDays(7), claims: claims, notBefore: DateTime.Now);
            JwtSecurityToken token = new JwtSecurityToken(header: header, payload: payload);
            return tokenHandler.WriteToken(token);
        }
        public static int GenerateOTPNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

    }
}
