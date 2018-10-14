using System;

namespace MathSite.Api.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string Login { get; set; }
    }
}