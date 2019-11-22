using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyBadgerTest.ProfileControllerTests
{
	public class MockProfileLogic : IProfileLogic
	{

		//create example data which will be used to test the controller.
		private readonly List<Profile> _ProfileList;


		//public  method that returns a list of profile objects.
		public List<Profile> TestProfiles()
		{
			List<Profile> TestProfiles_list = new List<Profile>();
			TestProfiles_list.Add(new Profile
			{
				ActualName = "Jimmy",
				DisplayName = "Dragon",
				Dob = new DateTime(1987,09,20),
				Email ="JimmyTheDragon@gmail.com",
				Gender = "Male",
				ProfileId = "763adcfc-2abc-493a-b35d-813d95905906",
				ProfileImage = null,
				Promotion = true,
				UserAddress = "600 Golden Acre Valley"


			});
			TestProfiles_list.Add(new Profile
			{
				ActualName = "Jenny",
				DisplayName = "JFenny",
				Dob = new DateTime(2000, 11, 10),
				Email = "JJEnders@hotmail.ca",
				Gender = "Female",
				ProfileId = "f9d2aad6-2b4a-4740-84f2-737fc3d06a76",
				ProfileImage = null,
				Promotion = false,
				UserAddress = "19 Oak Drive"
			});
			TestProfiles_list.Add(new Profile
			{
				ActualName = "Danny",
				DisplayName = "DanTheMan",
				Dob = new DateTime(1975, 01, 15),
				Email = "DMan@hotmai.com",
				Gender = "Male",
				ProfileId = "8ed22a94-fbdd-4014-8824-3bcb5e80792a",
				ProfileImage = null,
				Promotion = false,
				UserAddress = "100 Oscar Ave"
			});
			return TestProfiles_list;
		}

		//get the list of test profiles
		public MockProfileLogic()
		{
			_ProfileList = TestProfiles();
		}

		public bool Add(Profile profile)
		{
			profile.ProfileId = Guid.NewGuid().ToString();
			_ProfileList.Add(profile);
			return true;
		}

		public int Delete(string id)
		{
			try
			{
				Profile profileToBeDeleted = _ProfileList.Find(a => a.ProfileId == id);
				_ProfileList.Remove(profileToBeDeleted);
				return 1;
			}
			catch (Exception e)
			{
				return 0;
			}
			
		}

		public Profile Details(string id)
		{
			return _ProfileList.Find(x => x.ProfileId == id);
		}

		public IEnumerable<Profile> GetAll()
		{
			return _ProfileList;
		}

		public bool Update(Profile profile)
		{
			try
			{
				int found_profile_index = _ProfileList.FindIndex(x => x.ProfileId == profile.ProfileId);
				_ProfileList[found_profile_index] = profile;
				return true;
			}
			catch(Exception e)
			{
				return false;
			}
			
		}
	}
}
