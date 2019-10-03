using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers_3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers_3._0.DAL
{
	
	public class FetchGame
	{
		HoneyBadgerDBContext _context = new HoneyBadgerDBContext();
		//simple database access
		public IEnumerable<Game> getAllGames()
		{
			try
			{
				//need to make it async....
				return _context.Game.ToList();
			}
			catch
			{
                //need to fix catch
				throw;
			}
		}
	}
}
