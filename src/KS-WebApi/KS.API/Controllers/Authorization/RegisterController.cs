﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.Managers.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KS.API.Controllers.Authorization
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : Controller
	{
		private readonly IMapper _mapper;

		private readonly IRegisterUserManager _registerUserManager;

		public RegisterController(IRegisterUserManager registerUserManager, IMapper mapper)
		{
			_registerUserManager = registerUserManager;
			_mapper = mapper;
		}
		//public RegisterController(IRegisterUserManager _mockManager)
		//{
		//	_registerUserManager = _mockManager;
		//}
		[HttpPost("RegisterUser")]
		public async Task<IActionResult> Register([FromBody] NewUserCreateRequest userForRegister)
		{
			userForRegister.UserName = userForRegister.UserName.ToLower();
			var dto = _mapper.Map<NewUserCreateDTO>(userForRegister);
			var userCheck = await _registerUserManager.RegisterUser(dto);
			if (userCheck)
				return StatusCode(201);
			else
				return StatusCode(409, "It appears that username already exists.");
		}
	}
}
