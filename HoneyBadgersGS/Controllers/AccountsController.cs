using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private IAccountLogic _accountLogic;

		public AccountsController(IAccountLogic accountLogic)
		{
			_accountLogic = accountLogic;
		}

		// GET: api/Accounts
		[HttpGet]
		public IEnumerable<AspNetUsers> GetAccount()
		{
			return _accountLogic.GetAll().ToList();
		}

	}
}