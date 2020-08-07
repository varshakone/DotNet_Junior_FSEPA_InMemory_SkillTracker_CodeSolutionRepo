using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SkillTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace SkillTracker.DataLayer
{
    public class UserConnection : IUserConnection
    {
        private UserContext _userContext;
        public UserConnection(UserContext userContext)
        {
            _userContext = userContext;
        }
       public UserContext GetUserContext => _userContext;
    }
}
