using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
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
		public async Task<bool> RegisterUser(NewUserCreateDTO userDTO)
		{
			UserRegisterRAO userRAO = MapRegisterDTOtoRegisterRAO(userDTO);
			UserEntity userEntity = MapRegisterRAOtoUserEntity(userRAO);
			return await CreateUser(userEntity);
		}

		private async Task<bool> CreateUser(UserEntity userEntity)
		{
			await _context.UserTableAccess.AddAsync(userEntity);
			return await _context.SaveChangesAsync() == 1;
		}

		private UserEntity MapRegisterRAOtoUserEntity(UserRegisterRAO userRAO)
		{
			var entity = new UserEntity
			{
				OwnerId = userRAO.OwnerId,
				PasswordHash = userRAO.PasswordHash,
				PasswordSalt = userRAO.PasswordSalt,
				UserName = userRAO.UserName,
			};
			return entity;
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
