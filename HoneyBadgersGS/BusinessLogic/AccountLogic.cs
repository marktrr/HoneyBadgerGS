using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
	public class AccountLogic : IAccountDal
	{
		private IAccountDal _accountDal;

		public AccountLogic(IAccountDal accountDal)
		{
			_accountDal = accountDal;
		}

		public IEnumerable<AspNetUsers> GetAll()
		{
			return _accountDal.GetAll();
		}
	}
}
