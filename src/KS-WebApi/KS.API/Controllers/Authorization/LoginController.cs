using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KS.API.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
		private readonly IUserLoginManager _userLoginManager;
		private readonly IMapper _mapper;

		public LoginController(IUserLoginManager userLoginManager, IMapper mapper)
		{
			_userLoginManager = userLoginManager;
			_mapper = mapper;
		}
		[HttpPost ("UserLogin")]
		public async Task<IActionResult> Login([FromBody] UserLoginRequest userForLogin)
		{
			userForLogin.Username = userForLogin.Username.ToLower();
			var dto = _mapper.Map<ExistingUserDTO>(userForLogin);
			await _userLoginManager.UserLogin(dto);
			return StatusCode(200);
		}
    }
}