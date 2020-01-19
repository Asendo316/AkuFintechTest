﻿using Microsoft.AspNetCore.Mvc;
using AcuTestRestAPI.Domain.v1.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Services.Interfaces.v1.auth
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterUserAsync(string email, string password);

        Task<AuthenticationResult> LoginUserAsync(string email, string password);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);

    }
}
