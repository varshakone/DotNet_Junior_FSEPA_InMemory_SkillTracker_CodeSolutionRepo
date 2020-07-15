using Microsoft.EntityFrameworkCore;
using SkillTracker.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillTracker.Tests.Utility
{
   public class InMemoryDBUtility
    {
        private SkillContext _skillContext;
        private UserContext _userContext;
        private IUserConnection _userConnection;
        private ISkillConnection _skillConnection;
        public InMemoryDBUtility()
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

        public SkillContext GetSkillContext()
        {
            return _skillConnection.GetSkillContext;
        }

        public UserContext GetUserContext()
        {
            return _userConnection.GetUserContext;
        }
    }
}
