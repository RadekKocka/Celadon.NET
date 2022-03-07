﻿using DotNetTribes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTribes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController
    {
        private IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        // TODO: change the return type (ActionResult?)
        // TODO: add service (+ its interface) for registration
        [HttpPost]
        public void RegisterNewUser()
        {
            
        }
    }
}