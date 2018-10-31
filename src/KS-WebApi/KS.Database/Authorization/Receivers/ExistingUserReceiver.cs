using AutoMapper;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receivers
{
	public class ExistingUserReceiver : IUserLoginReceiver
	{
		private readonly KSContext _context;
		private readonly IMapper _mapper;

		public ExistingUserReceiver(KSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<bool> GetUserByUsername(UserLoginRAO userRAO)
		{
			var userEntity = _mapper.Map<UserEntity>(userRAO);
			//userEntity.OwnerId = userRAO.
			//userEntity.UserName =
			return true;
		}

		public Task<bool> UserLogin(UserLoginRAO userRAO)
		{
			throw new NotImplementedException();
		}
	}
}
