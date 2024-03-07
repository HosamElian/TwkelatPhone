﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Mobile.Models;

namespace Twkelat.Mobile.Repository.IRepository
{
    public interface ILoginRepository
    {
        Task<AuthModelResponse> Login(string email, string password);
    }
}
