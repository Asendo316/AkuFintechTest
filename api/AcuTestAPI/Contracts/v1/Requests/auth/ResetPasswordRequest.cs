﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Contracts.v1.Requests.auth
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
    }
}
