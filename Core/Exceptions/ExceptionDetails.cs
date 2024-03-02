﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class ExceptionDetails
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Title { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);


    }
}
