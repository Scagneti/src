using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
	public class UserLoginManager : IUserLoginManager
	{
		private readonly IUserLoginInvoker _userLoginInvoker;
		private readonly IMapper _mapper;
		private readonly IConfiguration _config;

		public UserLoginManager(IUserLoginInvoker userLoginInvoker, IMapper mapper, IConfiguration config)
		{
			_userLoginInvoker = userLoginInvoker;
			_mapper = mapper;
			_config = config;
		}
		public async Task<ExistingUserDTO> UserLogin(QueryForExistingUserDTO userDTO)
		{
			var rao = _mapper.Map<QueryForExistingUserRAO>(userDTO);

			var received = await _userLoginInvoker.InvokeLoginUserCommand(rao);

			var verifyEngine = new VerifyPasswordEngine();
			var match = verifyEngine.VerifyPasswordHash(userDTO.Password, received.PasswordHash, received.PasswordSalt);

			if (match)
				return _mapper.Map<ExistingUserDTO>(received);
			else
				throw new Exception("The password you used is incorrect.");
		}
		public string GenerateTokenForUser(ExistingUserDTO userDTO)
		{
			var tokenEngine = new GenerateTokenEngine(_config);
			var tokenString = tokenEngine.GenerateTokenString(userDTO);
			return tokenString;
		}
	}
}
