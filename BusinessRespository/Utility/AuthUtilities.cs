
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

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
        public static string GenerateOTPNo()
        {
            //int _min = 0;
            //int _max = 35;
            //Random _rdm = new Random();
            //return _rdm.Next(_min, _max);


            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string OTP = "";
            
            for (int i = 0; i < 5; i++)
            {
                int _min = 0;
                int _max = 35;
                Random _rdm = new Random();
                int randomNum =  _rdm.Next(_min, _max);

                OTP += str[randomNum];

            }
            return OTP;
        }

        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
