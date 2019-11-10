using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers._0.DataLayers
{
	public class AccountDal : IAccountDal
	{
		private HoneyBadgerDBContext _db;

		public AccountDal(HoneyBadgerDBContext db)
		{
			_db = db;
		}
		//get all the users
		public IEnumerable<AspNetUsers> GetAll()
		{
			return _db.AspNetUsers.ToList();
		}
	}
}
