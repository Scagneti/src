﻿using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KS.API
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// == USER REGISTRATION
			CreateMap<NewUserCreateRequest, NewUserCreateDTO>();
			CreateMap<NewUserCreateDTO, UserRegisterRAO>();
			CreateMap<UserRegisterRAO, UserEntity>();

			// == USER LOGIN
			CreateMap<UserLoginRequest, ExistingUserDTO>();
			CreateMap<ExistingUserDTO, UserLoginRAO>();
			CreateMap<UserLoginRAO, UserEntity>();
		}
	}
}
