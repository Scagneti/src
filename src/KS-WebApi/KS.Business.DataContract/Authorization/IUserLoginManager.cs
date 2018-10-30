using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
	public interface IUserLoginManager
	{
		Task<bool> UserLogin(ExistingUserDTO userDTO);
	}
}
