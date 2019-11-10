using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers._0.DataLayers
{
	public interface IAccountDal
	{
		IEnumerable<AspNetUsers> GetAll();
	}
}

