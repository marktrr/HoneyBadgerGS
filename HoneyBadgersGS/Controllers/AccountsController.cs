using System.Collections.Generic;
using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using Microsoft.AspNetCore.Mvc;
namespace HoneyBadgers._0.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountLogic _accountsLogic;
        private HoneyBadgerDBContext _db;
        private AspNetUsers aspNetUsers;

        public AccountsController(IAccountLogic accountsLogic)
        {
            _accountsLogic = accountsLogic;
        }
    

        // [HttpGet("getfriendList")]
        // [Route("api/Accounts")]
        // public AspNetUsers getfriendList()
        // {
        //      var friends = aspNetUsers 
        //     .FromSql("SELECT a.id, a.UserName from Friendship f JOIN AspNetUsers a ON a.id = f.accountID1 WHERE f.accountID2 = '67aabfde-e0f2-4e0b-8aa8-9134191bbe40' UNION SELECT a.id, a.UserName from Friendship f JOIN AspNetUsers a ON a.id = f.accountID2 WHERE f.accountID1 = '67aabfde-e0f2-4e0b-8aa8-9134191bbe40' ")
        //     .AsNoTracking().ToList();
            
        //         return friends;
        // }



        // public IActionResult Index()
        // {
        //     var Friends =   _db.Database.FromSql(
        //     "SELECT a.id, a.UserName from Friendship f JOIN AspNetUsers a ON a.id = f.accountID1 WHERE f.accountID2 = '67aabfde-e0f2-4e0b-8aa8-9134191bbe40' UNION SELECT a.id, a.UserName from Friendship f JOIN AspNetUsers a ON a.id = f.accountID2 WHERE f.accountID1 = '67aabfde-e0f2-4e0b-8aa8-9134191bbe40'").ToList();
        //     return Friends;
        // }

        [HttpGet("getaccounts")]
        [Route("api/Accounts")]
        public IEnumerable<AspNetUsers> GetAllAccounts()
        {
            return _accountsLogic.GetAll();
        }

        //TODO: Convert everything below this comment and remove DB context.

        //Add Single Game to Record
        [HttpPost]
        [Route("api/Accounts/Add")]
        public int Add(AspNetUsers account)
        {
            return _accountsLogic.Add(account);
        }

        //Updates Games in record
        [HttpPut]
        [Route("api/Accounts/Update")]
        public int Update(AspNetUsers account)
        {
            return _accountsLogic.Update(account);
        }

        //Get Single Game Details
        [HttpGet("getaccounts/{id}")]
        [Route("api/Accounts/Details/{id}")]
        public AspNetUsers Details(string id)
        {
            return _accountsLogic.Details(id);
        }

        //Delete game from records
        [HttpDelete]
        [Route("api/Games/Delete")]
        public int Delete(string id)
        {
            return _accountsLogic.Delete(id);
        }
    }
}