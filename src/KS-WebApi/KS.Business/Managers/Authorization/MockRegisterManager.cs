using AutoMapper;
using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
	public class MockRegisterManager :IRegisterUserManager
	{
		public Task<bool> ReturnValue { get; set; }
		public int CallCount { get; set; }

		public async Task<bool> RegisterUser(NewUserCreateDTO userDTO)
		{
			CallCount++;
			return await ReturnValue;
		}
	}
}
