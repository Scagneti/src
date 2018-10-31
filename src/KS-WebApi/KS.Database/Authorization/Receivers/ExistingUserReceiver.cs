using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using Microsoft.EntityFrameworkCore;
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
		public async Task<ExistingUserDTO> UserLogin(QueryForExistingUserRAO userRAO)
		{
			var entity = await _context.UserTableAccess.FirstOrDefaultAsync(x => x.UserName == userRAO.UserName);
			var login = _mapper.Map<ExistingUserDTO>(entity);

			return login;
		}
	}
}
