using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.Authorization.Invokers;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
	public class RegisterUserManager : IRegisterUserManager
	{
		private readonly IUserRegisterInvoker _userRegisterInvoker;

		public RegisterUserManager(IUserRegisterInvoker userRegisterInvoker)
		{
			_userRegisterInvoker = userRegisterInvoker;
		}
		public async Task<bool> RegisterUser(NewUserCreateRequest userRequest)
		{
			var dto = PrepareUserDTOForRegister(userRequest);
			return await _userRegisterInvoker.InvokeRegisterUserCommand(dto);

			//--Create new instance of Engine
			//--Store username in variable
			//--pass userrequest variable into password hash method
			//--Call CreatePasswordHash method
			//--Prepare the DTO object for the next layer
			//--Instantiate the class for the database
			//--Call the invoker method to access the DAL
		}
		private NewUserCreateDTO PrepareUserDTOForRegister(NewUserCreateRequest userRequest)
		{
			byte[] passwordHash, passwordSalt;

			var hashEngine = new CreatePasswordHashEngine();
			hashEngine.CreatePasswordHash(userRequest.Password, out passwordHash, out passwordSalt);

			var userDTO = MapUserRequestObjectToDTO(userRequest, passwordHash, passwordSalt);

			return userDTO;
		}

		private NewUserCreateDTO MapUserRequestObjectToDTO(NewUserCreateRequest userRequest, byte[] passwordHash, byte[] passwordSalt)
		{
			var userDTO = new NewUserCreateDTO
			{
				UserName = userRequest.UserName,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt

			};
			return userDTO;
		}

	}
}
