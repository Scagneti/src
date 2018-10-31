using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization;
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

		public UserLoginManager(IUserLoginInvoker userLoginInvoker, IMapper mapper)
		{
			_userLoginInvoker = userLoginInvoker;
			_mapper = mapper;
		}
		public async Task<bool> UserLogin(ExistingUserDTO userDTO)
		{
			var rao = PrepareUserRAOForLogin(userDTO);
			return await _userLoginInvoker.InvokeLoginUserCommand(rao);
		}

		private UserLoginRAO PrepareUserRAOForLogin(ExistingUserDTO userDTO)
		{

			var rao = _mapper.Map<UserLoginRAO>(userDTO);

			var verifyEngine = new VerifyPasswordEngine();
			var result = verifyEngine.VerifyPasswordHash(userDTO.Password, rao.PasswordHash, rao.PasswordSalt);

			if (result == true)
				return rao;
			throw new Exception();
		}
	}
}
