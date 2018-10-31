using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Invokers
{
	public class ExistingUserInvoker : IUserLoginInvoker
	{
		private readonly IUserLoginCommand _command;

		public ExistingUserInvoker(IUserLoginCommand command)
		{
			_command = command;
		}

		public async Task<ExistingUserDTO> InvokeLoginUserCommand(QueryForExistingUserRAO userRAO)
		{
			return await _command.Execute(userRAO);
		}
	}
}
