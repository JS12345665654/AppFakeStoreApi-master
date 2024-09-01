﻿using AppFakeStore.Models;

namespace AppFakeStore.Services
{
    public interface ILoginService
    {
        Task<string> AuthenticateAsync(Login login);
    }
}
