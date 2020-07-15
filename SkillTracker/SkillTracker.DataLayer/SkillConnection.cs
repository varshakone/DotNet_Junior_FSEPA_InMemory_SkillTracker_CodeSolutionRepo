using System;
using System.Collections.Generic;
using System.Text;
using SkillTracker.Entities;

namespace SkillTracker.DataLayer
{
    public class SkillConnection : ISkillConnection
    {
        private SkillContext _skillContext;
        public SkillConnection(SkillContext skillContext)
        {
            _skillContext = skillContext;
        }
    

        public SkillContext GetSkillContext => _skillContext;
    }
}
