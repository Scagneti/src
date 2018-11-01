using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
	public interface IUserLoginManager
	{
		Task<ExistingUserDTO> UserLogin(QueryForExistingUserDTO userDTO);
		string GenerateTokenForUser(ExistingUserDTO userDTO);
	}
}
