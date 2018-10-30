using AutoMapper;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Commands
{
	public class ExistingUserCommand : IUserLoginCommand
	{
		private readonly IUserLoginReceiver _userLoginReceiver;
		private readonly IMapper _mapper;

		public ExistingUserCommand(IUserLoginReceiver userLoginReceiver, IMapper mapper)
		{
			_userLoginReceiver = userLoginReceiver;
			_mapper = mapper;
		}

		public async Task<bool> Execute(UserLoginRAO userRAO)
		{
			return await _userLoginReceiver.UserLogin(userRAO);
		}
	}
}
