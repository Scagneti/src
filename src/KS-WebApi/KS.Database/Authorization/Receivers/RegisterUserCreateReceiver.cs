using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receivers
{
	public class RegisterUserCreateReceiver : IAuthorizationReceiver
	{
		private readonly KSContext _context;

		public RegisterUserCreateReceiver(KSContext context)
		{
			_context = context;
		}
		public Task<bool> RegisterUser(NewUserCreateDTO userDTO)
		{
			//Map DTO to RAO
			UserRegisterRAO userRAO = MapRegisterDTOtoRegisterRAO(userDTO);
			//Create GUID in RAO
			//Map the RAO to Entity
			//Create a User
			//SaveChanges() == 1

			throw new NotImplementedException();
		}

		private UserRegisterRAO MapRegisterDTOtoRegisterRAO(NewUserCreateDTO userDTO)
		{
			var userRAO = new UserRegisterRAO
			{
				OwnerId = Guid.NewGuid(),
				UserName = userDTO.UserName,
				PasswordHash = userDTO.PasswordHash,
				PasswordSalt = userDTO.PasswordSalt
			};
			return userRAO;
		}
	}
}
