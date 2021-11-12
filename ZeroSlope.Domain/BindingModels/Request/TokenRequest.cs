using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroSlope.Domain.BindingModels.Request
{
    public class TokenRequest
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
    }
}
