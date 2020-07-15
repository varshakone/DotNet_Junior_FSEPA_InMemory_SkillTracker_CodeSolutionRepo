using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SkillTracker.Web;
using SkillTracker.Web.Controllers;
using SkillTracker.DataLayer;
using Microsoft.Extensions.Configuration;
using SkillTracker.Entities;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;

namespace SkillTracker.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public  class FunctionalTest
    {
        // private references declaration
        static FileUtility fileUtility;
        private readonly InMemoryDBUtility _InMemoryDB;
        readonly IConfigurationRoot config;
        private Skill _skill;
        User _user;
        String testResult;
        private IUserService _userService;
        private ISkillService _skillService;

        public FunctionalTest()
        {
            _InMemoryDB = new InMemoryDBUtility();
            _userService = new UserService(_InMemoryDB.GetUserContext());
            _skillService = new SkillService(_InMemoryDB.GetSkillContext());
            _skill = new Skill
            {
                SkillName = "SpringBoot",
                SkillCategory = SkillCategory.Java,
                SkillLevel = SkillLevel.Biginner,
                SkillType = SkillType.Programming,
                SkillTotalExperiance = 1
            };

            _user = new User
            {

                FirstName = "Nyati",
                LastName = "nene",
                Email = "nyati@gmail.com",
                Mobile = 9685744263,
                MapSkills=2
            };

            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }
        static FunctionalTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_revised.txt";
            fileUtility.CreateTextFile();
        }

        //Test methods for Skill Controller
        [Fact]
        public async Task FunctionalTestFor_NewSkill_ActionMethod()
        {
            try
            {
                var skillController = new SkillController(_InMemoryDB.GetSkillContext());
                var result =await skillController.NewSkill(_skill) ;
                            
                if (result != null)
                {
                    testResult = "FunctionalTestFor_NewSkill_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_NewSkill_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun NewSkill action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull( result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_NewSkill_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_NewSkill_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expecting to retrun NewSkill action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_ReviseSkill_ActionMethod()
        {
            try
            {
                var skillController = new SkillController(_InMemoryDB.GetSkillContext());
                var rslt = _skillService.AddNewSkill(_skill);
                var result = skillController.ReviseSkill(_skill).Result;
                if (result != null)
                {
                    testResult = "FunctionalTestFor_ReviseSkill_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_ReviseSkill_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun ReviseSkill action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_ReviseSkill_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_ReviseSkill_ActionMethod",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "Expecting to retrun NewSkill action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_DestroySkill_ActionMethod()
        {
            try
            {
                var skillController = new SkillController(_InMemoryDB.GetSkillContext());
                var rslt = _skillService.AddNewSkill(_skill);
                var result = skillController.DestroySkill(_skill.SkillName).Result;
                if (result != null)
                {
                    testResult = "FunctionalTestFor_DestroySkill_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_DestroySkill_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun DestroySkill action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_DestroySkill_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_DestroySkill_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun DestroySkill action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for User Controller

        [Fact]
        public async Task FunctionalTestFor_NewUser_ActionMethod()
        {
            try
            {
                var userController = new UserController(_InMemoryDB.GetUserContext());
                var result = userController.NewUser(_user);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_NewUser_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_NewUser_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun NewUser action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_NewUser_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_NewUser_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun NewUser action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_ReviseUser_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                _user.Mobile = 9878898565;
                _user.MapSkills = 5;
                var userController = new UserController(_InMemoryDB.GetUserContext());
                var result = userController.ReviseUser(_user);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_ReviseUser_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_ReviseUser_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun NewUser action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_ReviseUser_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_ReviseUser_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun ReviseUser action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_DestroyUser_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                var userController = new UserController(_InMemoryDB.GetUserContext());
                var result = userController.DestroyUser(_user.FirstName,_user.LastName);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_DestroyUser_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_DestroyUser_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun DestroyUser action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_DestroyUser_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_DestroyUser_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun DestroyUser action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for Admin Controller
        [Fact]
        public async Task FunctionalTestFor_AllUsers_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                var adminController = new AdminController(_InMemoryDB.GetUserContext());
                var result = adminController.AllUsers();
                if (result != null)
                {
                    testResult = "FunctionalTestFor_AllUsers_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_AllUsers_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun allUser action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_AllUsers_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_AllUsers_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun allUser action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByFirstName_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                var adminController = new AdminController(_InMemoryDB.GetUserContext());
                var result = adminController.InspectUserByFirstName(_user.FirstName);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_InspectUserByFirstName_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserByFirstName_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun SearchUser action result by filtering user with FirstName"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_InspectUserByFirstName_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByFirstName_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun  SearchUser action result by filtering user with FirstName"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByEmail_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                var adminController = new AdminController(_InMemoryDB.GetUserContext());
                var result = adminController.InspectUserByEmail(_user.Email);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_InspectUserByEmail_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserByEmail_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun SearchUser action result by filtering user with Email ID"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_InspectUserByEmail_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByEmail_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun SearchUser action result by filtering user with Email ID"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByMobileNumber_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                var adminController = new AdminController(_InMemoryDB.GetUserContext());
                var result = adminController.InspectUserByMobile(_user.Mobile);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun SearchUser action result"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserByMobileNumber_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun SearchUser action result but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task FunctionalTestFor_InspectUserBySkillRange_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
                var adminController = new AdminController(_InMemoryDB.GetUserContext());
                var result = adminController.InspectUserBySkillRange(2);
                if (result != null)
                {
                    testResult = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Functional",
                            Name = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Expecting to retrun allUser action result with skill range 1-5"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                testResult = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Functional",
                        Name = "FunctionalTestFor_InspectUserBySkillRange_ActionMethod",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "Expecting to retrun allUser action result with skill range 1-5 but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
    }
}
