using SkillTracker.DataLayer;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using SkillTracker.Test.Utility;

namespace SkillTracker.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public class DatabaseConnectionTest
    {
        // private references
        static FileUtility fileUtility;
        private SkillContext _skillContext;
        private UserContext _userContext;
        private IUserConnection _userConnection;
        private ISkillConnection _skillConnection;
        static DatabaseConnectionTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_database_revised.txt";
            fileUtility.CreateTextFile();
        }
        public DatabaseConnectionTest()
        {
            DbContextOptions<SkillContext> contextOptions = new DbContextOptions<SkillContext>();
            DbContextOptionsBuilder optionsBuilderSkill = new DbContextOptionsBuilder(contextOptions);
            var dboption = optionsBuilderSkill.UseInMemoryDatabase().Options as DbContextOptions<SkillContext>;
            _skillContext = new SkillContext(dboption);

            DbContextOptions<UserContext> contextOptionsUser = new DbContextOptions<UserContext>();
            DbContextOptionsBuilder optionsBuilderUser = new DbContextOptionsBuilder(contextOptionsUser);
            var userdboption = optionsBuilderUser.UseInMemoryDatabase().Options as DbContextOptions<UserContext>;
            _userContext = new UserContext(userdboption);


            //Skill Connection
            _skillConnection = new SkillConnection(_skillContext);

            //User Connnection;
            _userConnection = new UserConnection(_userContext);
        }
        [Fact]
        public async Task DatabaseTestFor_InMemoryDBConnection_User()
        {
            try
            {
                var result = _userConnection.GetUserContext;
              
                if(result !=null)
                {
                     string testResult = "DatabaseTestFor_InMemoryDBConnection_User=" + "True";

                    // Write test case result in text file
                     fileUtility.WriteTestCaseResuItInText(testResult);
                }
                Assert.NotNull(result);
            }
            catch(Exception ex)
            {
                var error = ex;
                string testResult = "DatabaseTestFor_InMemoryDBConnection_User=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
            }
        }

        [Fact]
        public async Task DatabaseTestFor_InMemoryDBConnection_Skill()
        {
            try
            {
                var result = _skillConnection.GetSkillContext;

                if (result != null)
                {
                    string testResult = "DatabaseTestFor_InMemoryDBConnection_Skill=" + "True";

                    // Write test case result in text file
                  fileUtility.WriteTestCaseResuItInText(testResult);
                }
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                var error = ex;
                string testResult = "DatabaseTestFor_InMemoryDBConnection_Skill=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
            }
        }
    }
}

