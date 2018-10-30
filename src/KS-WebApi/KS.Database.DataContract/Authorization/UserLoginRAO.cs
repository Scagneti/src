using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.DataContract.Authorization
{
	public class UserLoginRAO
	{
		public string UserName { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
	}
}
