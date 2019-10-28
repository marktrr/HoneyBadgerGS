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
    public class ProfilesController : ControllerBase
    {
        private IProfileLogic _profileLogic;

        public ProfilesController(IProfileLogic profileLogic)
        {
            _profileLogic = profileLogic;
        }

        // GET: api/Profiles
        [HttpGet("getprofiles")]
        [Route("api/Profiles")]
        public IEnumerable<Profile> GetAllProfiles()
        {
            return _profileLogic.GetAll();
        }

        //Add Single Profile to records
        [HttpGet]
        [Route("api/Profiles/Add")]
        public int Add(Profile profile)
        {
            return _profileLogic.Add(profile);
        }

        //Update Profiles in records
        [HttpPut]
        [Route("api/Profiles/Update")]
        public int Update(Profile profile)
        {
            return _profileLogic.Update(profile);
        }

        //Get single profile details
        [HttpGet("getprofiles/{id}")]
        [Route("api/Profiles/Details/{id}")]
        public Profile Details(string id)
        {
            return _profileLogic.Details(id);
        }

        //Delete game from records
        [HttpDelete]
        [Route("api/Profiles/Delete")]
        public int Delete(string id)
        {
            return _profileLogic.Delete(id);
        }
    }
}
