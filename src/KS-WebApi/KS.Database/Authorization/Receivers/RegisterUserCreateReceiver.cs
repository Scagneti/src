using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receivers
{
	public class RegisterUserCreateReceiver : IAuthorizationReceiver
	{
		private readonly KSContext _context;
		private readonly IMapper _mapper;

		public RegisterUserCreateReceiver(KSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<bool> RegisterUser(UserRegisterRAO userRAO)
		{
			var userEntity = _mapper.Map<UserEntity>(userRAO);
			userEntity.OwnerId = Guid.NewGuid();
			var user = _context.UserTableAccess.SingleOrDefault(x => x.UserName == userRAO.UserName);
			if (user == null)
				return await CreateUser(userEntity);
			else
				return false;
		}

		private async Task<bool> CreateUser(UserEntity userEntity)
		{
			await _context.UserTableAccess.AddAsync(userEntity);
			return await _context.SaveChangesAsync() == 1;
		}
	}
}
