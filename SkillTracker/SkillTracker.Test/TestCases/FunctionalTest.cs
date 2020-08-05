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
using SkillTracker.Test.Utility;
using SkillTracker.BusinessLayer.Service.Repository;

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
        private IUserRepository _userRepository;
        private ISkillRepository _skillRepository;

        private readonly SkillController _skillController;
        private readonly UserController _userController;
        public FunctionalTest()
        {
            _InMemoryDB = new InMemoryDBUtility();
            _userRepository = new UserRepository(_InMemoryDB.GetUserContext());
            _userService = new UserService(_userRepository);

            _skillRepository = new SkillRepository(_InMemoryDB.GetSkillContext());
            _skillService = new SkillService(_skillRepository);

            _skillController = new SkillController(_skillService);
            _userController = new UserController(_userService);
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
                
                
                var result =await _skillController.NewSkill(_skill) ;
                            
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull( result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_ReviseSkill_ActionMethod()
        {
            try
            {
                
                var rslt = _skillService.AddNewSkill(_skill);
                var result = _skillController.ReviseSkill(_skill).Result;
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_DestroySkill_ActionMethod()
        {
            try
            {
                
                var rslt = _skillService.AddNewSkill(_skill);
                var result = _skillController.DestroySkill(_skill.SkillName).Result;
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for User Controller

        [Fact]
        public async Task FunctionalTestFor_NewUser_ActionMethod()
        {
            try
            {
               
                var result = _userController.NewUser(_user);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
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
               
                var result = _userController.ReviseUser(_user);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_DestroyUser_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
               
                var result = _userController.DestroyUser(_user.FirstName,_user.LastName);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
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
           
                var result = _userController.AllUsers();
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByFirstName_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
           
                var result = _userController.InspectUserByFirstName(_user.FirstName);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByEmail_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
           
                var result = _userController.InspectUserByEmail(_user.Email);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task FunctionalTestFor_InspectUserByMobileNumber_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
           
                var result = _userController.InspectUserByMobile(_user.Mobile);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task FunctionalTestFor_InspectUserBySkillRange_ActionMethod()
        {
            try
            {
                var rslt = _userService.CreateNewUser(_user);
           
                var result = _userController.InspectUserBySkillRange(2,3);
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
                         await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
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
                     await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
    }
}
