using AutoMapper;
using KS.API;
using KS.API.Controllers.Authorization;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.Managers.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace KS.UnitTests
{
	[TestClass]
	public class RegisterUserTests
	{
		private MockRegisterManager _mockManager;
		private RegisterController _mockController;

		[TestInitialize]
		public void Initialize()
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();

			_mockManager = new MockRegisterManager { ReturnValue = Task.FromResult(true)};
			_mockController = new RegisterController(_mockManager, mapper);
		}
		[TestMethod]
		public void RegisterManager_Registering_increases_call_count()
		{
			var request = new NewUserCreateRequest { UserName = "testName", Password = "testPassword" };
			var result = _mockController.Register(request);

			Assert.AreEqual(1, _mockManager.CallCount);		
		}
		[TestMethod]
		public void RegisterManager_Registering_returns_call_count()
		{
			var request = new NewUserCreateRequest { UserName = "testName", Password = "testPassword" };
			var result = (StatusCodeResult)_mockController.Register(request).Result;
			var expected = 201;

			Assert.AreEqual(result.StatusCode, expected);
		}
	}
}
