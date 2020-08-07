
using Microsoft.Extensions.Configuration;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.BusinessLayer.Service.Repository;
using SkillTracker.Entities;
using SkillTracker.Test.Utility;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SkillTracker.Tests.TestCases
{
    [Collection("parallel")]
    public  class BusinessLogicTest
    {
        // private reference declaration

        readonly IConfigurationRoot config;
        static FileUtility fileUtility;
        private readonly InMemoryDBUtility _InMemoryDB;
       private readonly Skill _skill;
        readonly User _user;
        private  IUserService _userService;
        private  ISkillService _skillService;
        String testResult;

        private IUserRepository _userRepository;
        private ISkillRepository _skillRepository;
        

        public BusinessLogicTest()
        {
            _InMemoryDB = new InMemoryDBUtility();

            _skill = new Skill
            {
                SkillName = ".Net core 3.1",
                SkillCategory = SkillCategory.DotNet,
                SkillLevel = SkillLevel.Intermediate,
                SkillType = SkillType.Programming,
                SkillTotalExperiance = 1
            };

            _user = new User
            {
                
                FirstName = "Dnyati",
                LastName = "Dube",
                Email = "dnyati@gmail.com",
                Mobile = 9685744263,
                MapSkills=2
            };
            _userRepository = new UserRepository(_InMemoryDB.GetUserContext());
            _userService = new UserService(_userRepository);

            _skillRepository = new SkillRepository(_InMemoryDB.GetSkillContext());
            _skillService = new SkillService(_skillRepository);
            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }
        static BusinessLogicTest()
        {
            fileUtility = new FileUtility
            {
                FilePath = "../../../../output_business_revised.txt"
            };
            fileUtility.CreateTextFile();
        }

       
        /// <summary>
        /// Test methods for Skill Service
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_AddNewSkill_Possitive()
        {
            try
            {
                var result = await _skillService.AddNewSkill(_skill);
                if (result == "New Skill Added")
                {
                    testResult = "BusinessTestFor_AddNewSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal("New Skill Added", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_AddNewSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_EditSkill_Possitive()
        {
            try
            {
                 var result1 = await _skillService.AddNewSkill(_skill);
                _skill.SkillLevel = SkillLevel.Expert;
                _skill.SkillTotalExperiance = 10;
                var result = await _skillService.EditSkill(_skill);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_EditSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_EditSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_DeleteSkill_Possitive()
        {
            try
            {
                var result1 = await _skillService.AddNewSkill(_skill);
                var result = await _skillService.DeleteSkill(_skill.SkillName);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_DeleteSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_DeleteSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
               
            }
        }

        //Test Methods for User Service

        [Fact]
        public async Task BusinessTestFor_CreateNewUser_Possitive()
        {
            try
            {
               
                var result = await _userService.CreateNewUser(_user);
                if(result == "New User Register")
                {
                    testResult = "BusinessTestFor_CreateNewUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal("New User Register", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_CreateNewUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_UpdateUser_Possitive()
        {
            try
            {
                
               
                var result1 = await _userService.CreateNewUser(_user);
                _user.Email = "dubednyati@gmail.com";
                _user.MapSkills = 2;
                var result = await _userService.UpdateUser(_user);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_UpdateUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_UpdateUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_RemoveUser_Possitive()
        {
            try
            {
                
               
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.RemoveUser(_user.FirstName, _user.LastName);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_RemoveUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_RemoveUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        //Test Methods for Admin Service
        [Fact]
        public async Task BusinessTestFor_AllUsers_Possitive()
        {
        try
            {
           
               
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.GetAllUsers();
                if (result !=null)
                {
                    testResult = "BusinessTestFor_AllUsers_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotEmpty(result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_AllUsers_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_SearchUserByFirstName_Possitive()
        {
            try
            {
            
               
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.SearchUserByFirstName(_user.FirstName) ;
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByFirstName_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Contains(_user.FirstName,result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_SearchUserByFirstName_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_SearchUserByEmail_Possitive()
        {
            try
            {
            
               
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.SearchUserByEmail(_user.Email);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByEmail_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_SearchUserByEmail_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task BusinessTestFor_SearchUserByMobileNumber_Possitive()
        {
            try
            {
            
               
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.SearchUserByMobile(_user.Mobile);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByMobileNumber_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_SearchUserByMobileNumber_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
        [Fact]
        public async Task BusinessTestFor_SearchUserBySkillRange_Possitive()
        {
            try
            {
            
               
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.SearchUserBySkillRange(2,5);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserBySkillRange_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                   
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "BusinessTestFor_SearchUserBySkillRange_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
    }
}
