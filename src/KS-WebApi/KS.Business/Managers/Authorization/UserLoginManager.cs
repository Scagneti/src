using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
	public class UserLoginManager
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
			throw new NotImplementedException();
		}
	}
}
