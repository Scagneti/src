using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Commands
{
	public class RegisterUserCreateCommand : IAuthorizationCommand
	{
		private readonly IAuthorizationReceiver _receiver;

		public RegisterUserCreateCommand(IAuthorizationReceiver receiver)
		{
			_receiver = receiver;
		}
		public Task<bool> Execute(NewUserCreateDTO userDTO)
		{
			return _receiver.RegisterUser(userDTO);
		}
	}
}
