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
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public  class ExceptionTest
    {
        // private references declaration
        static FileUtility fileUtility;
        readonly IConfigurationRoot config;
        String testResult;
        private IUserService _userService;
        private ISkillService _skillService;
        
        private readonly InMemoryDBUtility _InMemoryDB;
        private  Skill _skill;
         User _user;
        private IUserRepository _userRepository;
        private ISkillRepository _skillRepository;

        public ExceptionTest()
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
            };
            _userRepository = new UserRepository(_InMemoryDB.GetUserContext());
            _userService = new UserService(_userRepository);

            _skillRepository = new SkillRepository(_InMemoryDB.GetSkillContext());
            _skillService = new SkillService(_skillRepository);

            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }
        static ExceptionTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_exception_revised.txt";
            fileUtility.CreateTextFile();
        }






        //Test methods for Skill Service
        [Fact]
        public async Task ExceptionTestFor_AddNewSkill_Fail()
        {
            try
            {
                _skill = null;

               
                var result = await _skillService.AddNewSkill(_skill);
                if (result == "New Skill Added")
                {
                    testResult = "ExceptionTestFor_AddNewSkill_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_AddNewSkill_Fail",
                            expectedOutput = "False",
                            weight = 5,
                            mandatory = "False",
                            desc = "na"
                        };
                       await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual("New Skill Added", result);
                }
            }
            catch (Exception exception)
            {
                testResult = "ExceptionTestFor_AddNewSkill_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_AddNewSkill_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                   await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_EditSkill_Fail()
        {
            try
            {
                _skill.SkillLevel = SkillLevel.Expert;
                _skill.SkillTotalExperiance = 10;
               
                var result = await _skillService.EditSkill(_skill);
                if (result == 1)
                {
                    testResult = "ExceptionTestFor_EditSkill_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_EditSkill_Fail",
                            expectedOutput = "False",
                            weight = 5,
                            mandatory = "False",
                            desc = "na"
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_EditSkill_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_EditSkill_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_DeleteSkill_Fail()
        {
            try
            {

               
                var result = await _skillService.DeleteSkill(_skill.SkillName);
                if (result == 1)
                {
                    testResult = "ExceptionTestFor_DeleteSkill_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_DeleteSkill_Fail",
                            expectedOutput = "False",
                            weight = 5,
                            mandatory = "False",
                            desc = "na"
                        };
                       await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_DeleteSkill_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_DeleteSkill_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for User Service

        [Fact]
        public async Task ExceptionTestFor_CreateNewUser_Fail()
        {
            try
            {
                _user = null;
               
                var result = await _userService.CreateNewUser(_user);
                if (result == "New User Register")
                {
                    testResult = "ExceptionTestFor_CreateNewUser_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_CreateNewUser_Fail",
                            expectedOutput = "False",
                            weight = 5,
                            mandatory = "False",
                            desc = "allows to create new user and return success message"
                        };
                      await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual("New User Register", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_CreateNewUser_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_CreateNewUser_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "allows to create new user and expecting success message but throw exception"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_UpdateUser_Fail()
        {
            try
            {
                _user.Email = "dubednyati@gmail.com";
                _user.MapSkills =2;
               
                var result = await _userService.UpdateUser(_user);
                if (result == 1)
                {
                    testResult = "ExceptionTestFor_UpdateUser_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_UpdateUser_Fail",
                            expectedOutput = "False",
                            weight = 5,
                            mandatory = "False",
                            desc = "allows to update existing user and expecting 1 "
                        };
                       await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_UpdateUser_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_UpdateUser_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "allows to update existing user and expecting 1 but throw exception"
                    };
                await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_RemoveUser_Fail()
        {
            try
            {

               
                var result = await _userService.RemoveUser(_user.FirstName, _user.LastName);
                if (result == 1)
                {
                    testResult = "ExceptionTestFor_RemoveUser_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_RemoveUser_Fail",
                            expectedOutput = "False",
                            weight = 5,
                            mandatory = "False",
                            desc = "allows to delete existing user and expecting 1 "
                        };
                       await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual(1, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_RemoveUser_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_RemoveUser_Fail",
                        expectedOutput = "True",
                        weight = 1,
                        mandatory = "True",
                        desc = "allows to delete existing user and expecting 1 but throw exception"
                    };
                   await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for Admin Service
        [Fact]
        public async Task ExceptionTestFor_AllUsers_Fail()
        {
            try
            {
               
                var result = await _userService.GetAllUsers() as List<User>;
                if (result != null)
                {
                    testResult = "ExceptionTestFor_AllUsers_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_AllUsers_Fail",
                            expectedOutput = "False",
                            weight = 1,
                            mandatory = "False",
                            desc = "Shows list of users to admin user "
                        };
                       await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.InRange(result.Count, 1, 100);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_AllUsers_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_AllUsers_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "expecting  to shows list of users to admin user but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_SearchUserByFirstName_Fail()
        {
            try
            {
                _user.FirstName = null;
                var result = await _userService.SearchUserByFirstName(_user.FirstName);
                if (result != null)
                {
                    testResult = "ExceptionTestFor_SearchUserByFirstName_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_SearchUserByFirstName_Fail",
                            expectedOutput = "False",
                            weight = 1,
                            mandatory = "False",
                            desc = "na "
                        };
                      await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEqual(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_SearchUserByFirstName_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_SearchUserByFirstName_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_SearchUserByEmail_Fail()
        {
            try
            {
                _user.Email = null;
               
                var result = await _userService.SearchUserByEmail(_user.Email);
                if (result != null)
                {
                    testResult = "ExceptionTestFor_SearchUserByEmail_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_SearchUserByEmail_Fail",
                            expectedOutput = "False",
                            weight = 1,
                            mandatory = "False",
                            desc = "na "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_SearchUserByEmail_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_SearchUserByEmail_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task ExceptionTestFor_SearchUserByMobileNumber_Fail()
        {
            try
            {
                _user.Mobile = 0;
               
                var result = await _userService.SearchUserByMobile(_user.Mobile);
                if (result != null)
                {
                    testResult = "ExceptionTestFor_SearchUserByMobileNumber_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_SearchUserByMobileNumber_Fail",
                            expectedOutput = "False",
                            weight = 1,
                            mandatory = "False",
                            desc = "na "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_SearchUserByMobileNumber_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_SearchUserByMobileNumber_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task ExceptionTestFor_SearchUserBySkillRange_Fail()
        {
            try
            {
               
                var result = await _userService.SearchUserBySkillRange(2,4);
                if (result != null)
                {
                    testResult = "ExceptionTestFor_SearchUserBySkillRange_Fail=" + "False";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_SearchUserBySkillRange_Fail",
                            expectedOutput = "False",
                            weight = 1,
                            mandatory = "False",
                            desc = "na "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_SearchUserBySkillRange_Fail=" + "True";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_SearchUserBySkillRange_Fail",
                        expectedOutput = "True",
                        weight = 5,
                        mandatory = "True",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
    }
}
